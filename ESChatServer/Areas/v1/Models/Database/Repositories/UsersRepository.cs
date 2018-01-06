﻿using ESChatServer.Areas.v1.Models.Database.Entities;
using ESChatServer.Areas.v1.Models.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESChatServer.Areas.v1.Models.Database.Repositories
{
    public class UsersRepository : Repository<User>, IUsersRepository
    {
        public UsersRepository(DatabaseContext context) : base(context)
        {
        }

        public override void Add(User item, bool saveChanges)
        {
            this._DatabaseContext.Users.Add(item);

            if (saveChanges)
                this.SaveChanges();
        }
        public override async Task AddAsync(User item, bool saveChanges)
        {
            await this._DatabaseContext.Users.AddAsync(item);

            if (saveChanges)
                await this.SaveChangesAsync();
        }

        public override User Find(object id)
        {
            return this._DatabaseContext.Users.Find(id);
        }
        public override async Task<User> FindAsync(object id)
        {
            return await this._DatabaseContext.Users.FindAsync(id);
        }

        public override ICollection<User> FindAll()
        {
            return this._DatabaseContext.Users.ToList();
        }
        public override async Task<List<User>> FindAllAsync()
        {
            return await this._DatabaseContext.Users.ToListAsync();
        }

        public override void Remove(User item, bool saveChanges)
        {
            this._DatabaseContext.Users.Remove(item);

            if (saveChanges)
                this.SaveChanges();
        }
        public override async Task RemoveAsync(User item, bool saveChanges)
        {
            this._DatabaseContext.Users.Remove(item);

            if (saveChanges)
                await this.SaveChangesAsync();
        }

        public override void Update(User item, bool saveChanges)
        {
            User user = this.Find(item.ID);
            user.FirstName = item.FirstName;
            user.MiddleName = item.MiddleName;
            user.LastName = item.LastName;
            user.Birthdate = item.Birthdate;
            user.Gender = item.Gender;
            user.Username = item.Username;
            if (item.PasswordHash != null)
            {
                user.PasswordHash = item.PasswordHash;
            }
            if (item.PasswordSalt != null)
            {
                user.PasswordSalt = item.PasswordSalt;
            }
            user.UTCRegistrationDate = item.UTCRegistrationDate;

            //TODO: Update virtual properties?
            //user.Logins = item.Logins;

            if (saveChanges)
                this.SaveChanges();
        }
        public override async Task UpdateAsync(User item, bool saveChanges)
        {
            User user = await this.FindAsync(item.ID);
            user.FirstName = item.FirstName;
            user.MiddleName = item.MiddleName;
            user.LastName = item.LastName;
            user.Birthdate = item.Birthdate;
            user.Gender = item.Gender;
            user.Username = item.Username;
            if (item.PasswordHash != null)
            {
                user.PasswordHash = item.PasswordHash;
            }
            if (item.PasswordSalt != null)
            {
                user.PasswordSalt = item.PasswordSalt;
            }
            user.UTCRegistrationDate = item.UTCRegistrationDate;

            //TODO: Update virtual properties?
            //user.Logins = item.Logins;

            if (saveChanges)
                await this.SaveChangesAsync();
        }

        public User FindByUsername(string username)
        {
            return this._DatabaseContext.Users.Where(x => x.Username == username).FirstOrDefault();
        }
        public async Task<User> FindByUsernameAsync(string username)
        {
            return await this._DatabaseContext.Users.Where(x => x.Username == username).FirstOrDefaultAsync();
        }

        public override bool Exists(object id)
        {
            return this.Find(id) != null;
        }
        public override async Task<bool> ExistsAsync(object id)
        {
            return await this.FindAsync(id) != null;
        }

        public ICollection<User> FindByUsernameIncomplete(string username)
        {
            return this._DatabaseContext.Users.Where(x => x.Username.Contains(username)).ToList();
        }
        public async Task<ICollection<User>> FindByUsernameIncompleteAsync(string username)
        {
            return await this._DatabaseContext.Users.Where(x => x.Username.Contains(username)).ToListAsync();
        }
    }
}
