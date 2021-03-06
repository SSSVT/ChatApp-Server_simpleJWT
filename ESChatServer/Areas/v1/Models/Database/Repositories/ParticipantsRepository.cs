﻿using ESChatServer.Areas.v1.Models.Database.Entities;
using ESChatServer.Areas.v1.Models.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ESChatServer.Areas.v1.Models.Database.Repositories
{
    public class ParticipantsRepository : Repository<Participant>, IParticipantsRepository
    {
        public ParticipantsRepository(DatabaseContext context) : base(context)
        {
        }

        public void Add(Participant item, bool saveChanges)
        {
            this._DatabaseContext.Participants.Add(item);

            if (saveChanges)
                this.SaveChanges();
        }
        public async Task AddAsync(Participant item, bool saveChanges)
        {
            await this._DatabaseContext.Participants.AddAsync(item);

            if (saveChanges)
                await this.SaveChangesAsync();
        }

        public Participant Find(object id)
        {
            return this._DatabaseContext.Participants.Find(id);
        }
        public async Task<Participant> FindAsync(object id)
        {
            return await this._DatabaseContext.Participants.FindAsync(id);
        }

        public ICollection<Participant> FindAll()
        {
            return this._DatabaseContext.Participants.ToList();
        }
        public async Task<List<Participant>> FindAllAsync()
        {
            return await this._DatabaseContext.Participants.ToListAsync();
        }

        public void Remove(Participant item, bool saveChanges)
        {
            this._DatabaseContext.Participants.Remove(item);

            if (saveChanges)
                this.SaveChanges();
        }
        public async Task RemoveAsync(Participant item, bool saveChanges)
        {
            this._DatabaseContext.Participants.Remove(item);

            if (saveChanges)
                await this.SaveChangesAsync();
        }

        public void Update(Participant item, bool saveChanges)
        {
            Participant participant = this.Find(item.ID);
            participant.IDRoom = item.IDRoom;
            participant.IDUser = item.IDUser;

            //TODO: Update virtual properties?
            //participant.Room = item.Room;
            //participant.User = item.User;

            if (saveChanges)
                this.SaveChanges();
        }
        public async Task UpdateAsync(Participant item, bool saveChanges)
        {
            Participant participant = await this.FindAsync(item.ID);
            participant.IDRoom = item.IDRoom;
            participant.IDUser = item.IDUser;

            //TODO: Update virtual properties?
            //participant.Room = item.Room;
            //participant.User = item.User;

            if (saveChanges)
                await this.SaveChangesAsync();
        }

        public ICollection<Participant> FindByUserID(long id)
        {
            return this._DatabaseContext.Participants.Where(x => x.IDUser == id).ToList();
        }
        public async Task<ICollection<Participant>> FindByUserIDAsync(long id)
        {
            return await this._DatabaseContext.Participants.Where(x => x.IDUser == id).ToListAsync();
        }

        public ICollection<Participant> FindByRoomID(long id)
        {
            return this._DatabaseContext.Participants.Where(x => x.IDRoom == id).Include(x => x.User).ToList();
        }
        public async Task<ICollection<Participant>> FindByRoomIDAsync(long id)
        {
            return await this._DatabaseContext.Participants.Where(x => x.IDRoom == id).Include(x => x.User).ToListAsync();
        }

        public bool Exists(object id)
        {
            return this.Find(id) != null;
        }
        public async Task<bool> ExistsAsync(object id)
        {
            return await this.FindAsync(id) != null;
        }
    }
}
