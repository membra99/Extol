﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Universal.MainData;

namespace Universal.DTO.CommonModels
{
    public class CommonModels
    {   
        //authenticate models
        public class AuthenticateResponse
        {
            public int Id { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public string? Username { get; set; }
            public string Token { get; set; }


            public AuthenticateResponse(Users user, string token)
            {
                Id = user.UsersId;
                FirstName = user.FirstName;
                LastName = user.LastName;
                Username = user.Email;
                Token = token;
            }
        }

        public class AuthenticateRequest
        {
            [Required]
            public string? Username { get; set; }

            [Required]
            public string? Password { get; set; }
        }

        public class ResponseAuthModel
        {
            public int? id { get; set; }
            public string? firstName { get; set; }
            public string? lastName { get; set; }
            public string? username { get; set; }
            public string? token { get; set; }
        }

    }
}
