﻿namespace WebApiReynoVerde.DTO
{
    public class RegistrationResponseDto
    {
        public bool IsSuccessfulRegistration { get; set; }  
        public IEnumerable<string> Errors { get; set; }
    }
}
