using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using SimpleAuthentication.Interface;
using SimpleAuthentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace SimpleAuthentication.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly IInstructorRepository instructorRepository;

        public UserService(IUserRepository userRepository, IInstructorRepository instructorRepository)
        {
            this.userRepository = userRepository;
            this.instructorRepository = instructorRepository;
        }

        public User LoginUser(string email, string password)
        {
            User user = userRepository.FindUserByEmail(email);

            if (user == null) {
                Console.WriteLine("User not found");
                return null;
             }

            string hashedPassword = HashPassword(password, user.HashSalt);

            if (user.PasswordHash.Equals(hashedPassword))
            {
                Console.WriteLine("User is found");
                return user;
            }

            return null;
        }

        public void RegisterUser(string email, string fullname, string password, string userType)
        {
            byte[] salt = new byte[128 / 8];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string saltString = Convert.ToBase64String(salt);

            string hashedPassword = HashPassword(password, saltString);

            User user = new User
            {
                Id = Guid.NewGuid(),
                Email = email,
                HashSalt = saltString,
                PasswordHash = hashedPassword,
                Role = userRepository.FindRole(userType.ToLower())
            };

            userRepository.AddUser(user);

            Instructor instructor = new Instructor
            {
                UserId = user.Id,
                FullName = fullname,
                Address = "Abeokuta"
            };

            instructorRepository.Add(instructor);

        }

        private string HashPassword(string password, string salt)
        {
            byte[] saltByte = Convert.FromBase64String(salt);
            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: saltByte,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            Console.WriteLine($"Hashed: {hashed}");

            return hashed;
        }
    }
}
