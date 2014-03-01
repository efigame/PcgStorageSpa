﻿using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Dto
{
    public class PcgUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public static PcgUser Get(string email, string password)
        {
            PcgUser pcgUser = null;

            using (var data = new PcgStorageEntities())
            {
                var user = data.pcgusers.FirstOrDefault(u => u.Email == email && u.Password == password);
                if (user != null) pcgUser = new PcgUser(user);
            }

            return pcgUser;
        }
        public static List<PcgUser> All()
        {
            var allUsers = new List<PcgUser>();

            using (var data = new PcgStorageEntities())
            {
                var all = data.pcgusers.ToList();
                allUsers.AddRange(all.Select(u => new PcgUser(u)));
            }

            return allUsers;
        }
        public static bool CheckUserByEmail(string email)
        {
            var found = false;

            using (var data = new PcgStorageEntities())
            {
                var pcgUser = data.pcgusers.FirstOrDefault(u => u.Email == email);
                if (pcgUser != null) found = true;
            }

            return found;
        }

        public void Persist()
        {
            using (var data = new PcgStorageEntities())
            {
                var pcgUser = ToEntity();

                data.pcgusers.Add(pcgUser);
                data.SaveChanges();

                Id = pcgUser.Id;
            }
        }
        public void Update()
        {
            using (var data = new PcgStorageEntities())
            {
                var pcgUser = data.pcgusers.SingleOrDefault(u => u.Id == Id);
                if (pcgUser != null)
                {
                    pcgUser.Email = Email;
                    pcgUser.Password = Password;
                    data.SaveChanges();
                }
            }
        }
        public void Delete()
        {
            using (var data = new PcgStorageEntities())
            {
                var pcgUser = data.pcgusers.SingleOrDefault(u => u.Id == Id);
                if (pcgUser != null)
                {
                    data.pcgusers.Remove(pcgUser);
                    data.SaveChanges();
                }
            }
        }

        public PcgUser()
        {
        }

        internal PcgUser(pcguser pcgUser)
        {
            Id = pcgUser.Id;
            Email = pcgUser.Email;
            Password = pcgUser.Password;
        }
        internal pcguser ToEntity()
        {
            var pcgUser = new pcguser
            {
                Email = Email,
                Password = Password
            };

            return pcgUser;
        }
    }
}
