using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ProfileProject.Models;

namespace ProfileProject.Services
{
    public class ProfileManager :IRepo<Bio>
    {
        private BioContext _context;
        private ILogger<ProfileManager> _logger;

        public ProfileManager(BioContext context, ILogger<ProfileManager> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add(Bio t)
        {
            try
            {
                _context.Bios.Add(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
        }

        public void Delete(Bio t)
        {
            try
            {
                _context.Bios.Remove(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
        }

        public Bio Get(int id)
        {
            try
            {
                Bio profile = _context.Bios.FirstOrDefault(a => a.Id == id);
                return profile;
            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public IEnumerable<Bio> GetAll()
        {
            try
            {
                if (_context.Bios.Count() == 0)
                    return null;
                return _context.Bios.ToList();

            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
            }
            return null;
        }

        public void Update(int id, Bio t)
        {
            Bio profile = Get(id);
            if (profile != null)
            {
                profile.Name = t.Name;
                profile.Age = t.Age;
                profile.Qualification = t.Qualification;
                profile.IsEmployed = t.IsEmployed;
                profile.NoticePeriod = t.NoticePeriod;
                profile.CurrentCTC = t.CurrentCTC;

            }
            _context.SaveChanges();
        }
    }
}
