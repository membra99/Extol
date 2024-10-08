﻿using AutoMapper;
using Entities.Context;
using Entities.Universal.MainData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Services.Authorization;
using Services.AWS;
using Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Universal.DTO.IDTO;
using Universal.DTO.ODTO;
using static Universal.DTO.CommonModels.CommonModels;

namespace Services
{
	public class UsersServices : BaseServices
	{
		private readonly IJwtUtils _jwtUtils;
		private readonly IAWSS3FileService _AWSS3FileService;
		private readonly IOptions<EmailSettings> _emailSettings;
        private readonly IOptions<URL> _urlDomain;
        private readonly IHttpContextAccessor _httpContextAccessor;

		public static string AppBaseUrl = "";

		public UsersServices(MainContext context, IMapper mapper, IJwtUtils jwtUtils, IHttpContextAccessor httpContext, IAWSS3FileService AWSS3FileService, IOptions<EmailSettings> emailSettings, IOptions<URL> urlDomain) : base(context, mapper)
		{
			_jwtUtils = jwtUtils;
			_AWSS3FileService = AWSS3FileService;
			_emailSettings = emailSettings;
			_httpContextAccessor = httpContext;
            _urlDomain = urlDomain;
            AppBaseUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}";
		}

		#region Users

		public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
		{
			var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == model.Username);

			if (user != null)
			{
				if (!BCrypt.Net.BCrypt.Verify(model.Password, user.Password)) user = null; //failed password authentication
			}

			// return null if user not found
			if (user == null) return null;

			// authentication successful so generate jwt token
			var token = _jwtUtils.GenerateJwtToken(user);

			AuthenticateResponse authenticateResponse = new AuthenticateResponse(user, token);
			return authenticateResponse;
		}

		private IQueryable<UsersODTO> GetUsers(int id)
		{
			return from x in _context.Users
				   .Include(x => x.Media)
				   where (id == 0 || x.UsersId == id)
				   select _mapper.Map<UsersODTO>(x);
		}

		private IQueryable<UsersIDTO> GetUsers(string password)
		{
			return from x in _context.Users
				   .Include(x => x.Media)
				   where (password == "" || x.Password == password)
				   select _mapper.Map<UsersIDTO>(x);
		}

		public async Task<List<UsersODTO>> GetAllUsers()
		{
			return await GetUsers(0).AsNoTracking().ToListAsync();
		}

		public async Task<string> RedirectLink(string key)
		{
			var user = await _context.Users.Where(x => x.Password == key).SingleOrDefaultAsync();
			if (user != null)
			{
				user.IsActive = true;
				_context.Entry(user).State = EntityState.Modified;
				await SaveContextChangesAsync();

				return "https://www.google.com";
			}
			return null;

		}

		public async Task<UsersODTO> GetUserById(int id)
		{
			return await GetUsers(id).AsNoTracking().SingleOrDefaultAsync();
		}

		public async Task<UsersIDTO> GetUserByIdForEdit(int id)
		{
			return _mapper.Map<UsersIDTO>(await _context.Users.Include(x => x.Media).Where(x => x.UsersId == id).AsNoTracking().SingleOrDefaultAsync());
		}

		public async Task<UsersIDTO> GetUserByPassword(string password)
		{
			return await GetUsers(password).AsNoTracking().SingleOrDefaultAsync();
		}

		public async Task<UsersODTO> AddUser(UsersIDTO userIDTO)
		{
			var CheckUser = await _context.Users.Where(x => x.Email == userIDTO.Email).FirstOrDefaultAsync();
			if (CheckUser != null)
			{
				return null;
			}
			var user = _mapper.Map<Users>(userIDTO);
			user.IsActive = true;

			//initial user set, password is temp and user is instructed to change their password by mail
			user.UsersId = 0;
			user.Password = BCrypt.Net.BCrypt.HashPassword("tempPasswordDOTUniversalABC123456789012301231");

			MailService ms = new MailService(_emailSettings);
			string userKey = user.Password; // CHANGE IF NEEDED TO SOMETHING ELSE
			ms.SendEmail(new EmailIDTO
			{
				To = user.Email,
				Subject = user.FirstName + ", please set your password in order to access your new account!",
				Body = "Press the activation link to set your password and gain access to your account. <br> <a href='" + AppBaseUrl + "/Dashboard/SetPassword?key=" + userKey + "'>Set your password</a>"
			});
			try
			{
				_context.Users.Add(user);

				await SaveContextChangesAsync();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}

			return await GetUserById(user.UsersId);
		}

		public async Task<string> RegisterUser(UsersRegisterIDTO userIDTO)
		{
			string pattern = "^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&.])[A-Za-z\\d@$!%*?&.]{8,}$";
			var CheckUser = await _context.Users.Where(x => x.Email == userIDTO.Email).FirstOrDefaultAsync();
			if (CheckUser != null)
			{
				return "EmailExists";
			}
			if (!Regex.IsMatch(userIDTO.Password, pattern))
			{
				return "RegexException";
			}
			var user = _mapper.Map<Users>(userIDTO);

			//initial user set, password is temp and user is instructed to change their password by mail
			user.UsersId = 0;
			user.Password = BCrypt.Net.BCrypt.HashPassword("tempPasswordDOTUniversalABC123456789012301231");

			MailService ms = new MailService(_emailSettings);
			string userKey = user.Password; // CHANGE IF NEEDED TO SOMETHING ELSE
			ms.SendEmail(new EmailIDTO
			{
				To = user.Email,
				Subject = user.FirstName + ", please activate your account!",
				Body = "Thank you for registering on our site.<br> To verify your registration, click on this link: <br> <a href='"+_urlDomain.Value.MainUrl+"api/Users/Redirect?key=" + userKey + "'>Activate Your Mail</a>"
			});
			_context.Users.Add(user);

			await SaveContextChangesAsync();

			return "Done";
		}

		public async Task<MediaODTO> UploadUserPicture(AWSFileUpload awsFile, int? mediatypeId)
		{
			string successUpload = "";

			if (awsFile.Attachments.Count > 0)
				successUpload = await _AWSS3FileService.UploadFile(awsFile);

			if (successUpload != null)
			{
				var key = await _AWSS3FileService.FilesListSearch(successUpload);
				var media = new Media();
				media.Extension = successUpload.Split('.')[1];
				media.Src = key.First();
				media.MediaTypeId = (mediatypeId == null) ? _context.MediaTypes.Where(x => x.MediaTypeName == "Avatar").Select(x => x.MediaTypeId).FirstOrDefault() : (int)mediatypeId;
				var index = media.Src.LastIndexOf('/');
				media.MetaTitle = media.Src.Substring(index + 1);
				media.MimeType = awsFile.Attachments[0].ContentType;
				try
				{
					_context.Medias.Add(media);
					await _context.SaveChangesAsync();
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.ToString());
				}

				return _mapper.Map<MediaODTO>(media);
			}
			else
			{
				return null;
			}
		}

		public async Task<UsersODTO> EditUser(UsersIDTO userIDTO)
		{
			var user = _mapper.Map<Users>(userIDTO);
			if (userIDTO.IsImageChanged == "true" && userIDTO.MediaId == null)
				user.MediaId = null;
			_context.Entry(user).State = EntityState.Modified;
			if (userIDTO.Avatar == null && userIDTO.IsImageChanged != "true")
			{
				_context.Entry(user).Property(x => x.MediaId).IsModified = false;
			}
            _context.Entry(user).Property(x => x.Password).IsModified = false;
            user.IsActive = true;
			await SaveContextChangesAsync();

			return await GetUserById(user.UsersId);
		}

        public async Task<string> SendPasswordResetMail(string userMail)
        {
            var oldPaswd = await _context.Users.Where(x => x.Email == userMail).FirstOrDefaultAsync();
            if (oldPaswd == null)
                return "Korisnik nije pronađen";

            MailService ms = new MailService(_emailSettings);
            ms.SendEmail(new EmailIDTO
            {
                To = userMail,
                Subject = "Reset password",
                Body = "Hello, we have received a request to change your password. If you did not initiate this request, feel free to ignore this email" + "<br/>" +
                "If you have requested a password change, click on the following link and enter your new password " + "<a href='https://localhost:7213/Dashboard/SetPassword?key=" + oldPaswd.Password + "'> Change Password</a>"
            });

            return "Password reset mail has been sent to your email address";
        }

        public async Task<UsersODTO> DeleteUser(int id)
		{
			var user = await _context.Users.FindAsync(id);
			if (user == null) return null;

			var userODTO = await GetUserById(id);

			var orders = await _context.Orders.Where(x => x.UsersId == id).ToListAsync();
			foreach (var order in orders)
			{
				_context.Orders.Remove(order);
			}

			_context.Users.Remove(user);
			await SaveContextChangesAsync();

			return userODTO;
		}

		#endregion Users
	}
}