using System;
using System.Text;
using dotnetcore._2.x.DTO;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace dotnetcore._2.x.Services
{
    public interface IHashesService
    {
        hashResponse hashPassword(hashRequest hashRequest);
        hashResponse hashVerify(hashVerifyRequest hashRequest);
    }
    public class HashesService : IHashesService
    {
        public HashesService()
        {
        }

        public hashResponse hashPassword(hashRequest hashRequest)
        {
            var response = new hashResponse();
            int iterations = hashRequest.iterations.HasValue ? (int)hashRequest.iterations : 36000;
            try
            {
                switch (hashRequest.Algorithm)
                {
                    case "bcrypt":
                        response.HashedPassword = BCrypt.Net.BCrypt.HashPassword(hashRequest.Password);
                        break;
                    case "sha256":
                        byte[] salt = Encoding.ASCII.GetBytes(hashRequest.Salt);
                        response.HashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                        password: hashRequest.Password,
                        salt: salt,
                        prf: KeyDerivationPrf.HMACSHA256,
                        iterationCount: iterations,
                        numBytesRequested: 256 / 8));
                        break;
                }
            }
            catch (System.Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public hashResponse hashVerify(hashVerifyRequest hashRequest)
        {
            var response = new hashResponse();
            int iterations = hashRequest.iterations.HasValue ? (int)hashRequest.iterations : 36000;
            try
            {
                switch (hashRequest.Algorithm)
                {
                    case "bcrypt":
                        response.Matched = BCrypt.Net.BCrypt.Verify(hashRequest.Password, hashRequest.HashedPassword);
                        break;
                    case "sha256":
                        byte[] salt = Encoding.ASCII.GetBytes(hashRequest.Salt);
                        var hashedPassword = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                        password: hashRequest.Password,
                        salt: salt,
                        prf: KeyDerivationPrf.HMACSHA256,
                        iterationCount: iterations,
                        numBytesRequested: 256 / 8));
                        response.Matched = hashedPassword == hashRequest.HashedPassword;
                        break;
                }
            }
            catch (System.Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
    }
}