
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StarTEDSystem.DAL;
using StarTEDSystem.Entities;

namespace StarTEDSystem.BLL
{
    public class ClubServices
    {
        #region setup of the context connection variable and class constructor
        private readonly StarTEDContext _context;

        internal ClubServices(StarTEDContext registeredcontext)
        {
            _context = registeredcontext;
        }
        #endregion


        #region Queries

        public List<Club> GetAllClubs()
        {
            IEnumerable<Club> info = _context.Clubs;
            return info.ToList();
        }

        public List<Club> GetClubsByStatus(bool isActive)
        {
            IEnumerable<Club> info = _context.Clubs.OrderBy(p => p.ClubName).Include(x => x.Employee).Where(p => p.Active == isActive);
            return info.ToList();
        }

        public int GetClubsCountByStatus(bool isActive)
        {
            var info = _context.Clubs.OrderBy(p => p.ClubName).Include(x => x.Employee).Where(p => p.Active == isActive);
            return info.Count();
        }

        public List<Club> GetClubs(bool isActive, int itemsPerPage, int currentPage)
        {
            IEnumerable<Club> info = _context.Clubs.OrderBy(p => p.ClubName).Include(x => x.Employee).Where(p => p.Active == isActive).Skip(itemsPerPage * (currentPage - 1)).Take(itemsPerPage);
            return info.ToList();
        }


        public Club Club_GetByClubID(string clubID)
        {
            Club info = _context.Clubs.Where(p => p.ClubID == clubID).FirstOrDefault();
            return info;
        }

        



        #endregion



        #region Maintenance Services: Add, Update and Delete

        public int Club_Add(Club club)
        {
            if (club == null)
            {
                throw new ArgumentNullException("You must supply the club information");
            }

            bool exist = _context.Clubs.Any(p => p.ClubID == club.ClubID);

            if (exist)
            {
                throw new ArgumentException($"Club ID {club.ClubID} has already exists on file.");
            }
            exist = _context.Clubs.Any(p => p.ClubName == club.ClubName);
            if (exist)
            {
                throw new ArgumentException($"Club Name {club.ClubName} has already exists on file.");
            }
            club.Active = true;
            _context.Clubs.Add(club);
           int rowsaffected = _context.SaveChanges();


            return rowsaffected;
        }

        public int Club_Update(Club club)
        {
            if (club == null)
            {
                throw new ArgumentNullException("You must supply the club information");
            }
            bool exist = _context.Clubs.Any(p => p.ClubID == club.ClubID);

            if (!exist)
            {
                throw new ArgumentException($"Club ID {club.ClubID} does not exist on file.");
            }

            exist = _context.Clubs.Any(p => p.ClubName.Equals(club.ClubName) && !p.ClubID.Equals(club.ClubID) );

            if (exist)
            {
                throw new ArgumentException($"Club Name {club.ClubName} has already existed on file.");
            }

            //staging
            EntityEntry<Club> updating = _context.Entry(club);
            updating.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            //commit
            int rowsaffected = _context.SaveChanges();
            return rowsaffected;

        }

        public int Club_ActivateDeactivate(Club club, bool active)
        {
            if (club == null)
            {
                throw new ArgumentNullException("You must supply the club information");
            }

            Club exist = _context.Clubs.Where(p => p.ClubID == club.ClubID).FirstOrDefault();

            if (exist != null)
            {

                exist.Active = active;

                EntityEntry<Club> updating = _context.Entry(club);
                updating.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                int rowsaffected = _context.SaveChanges();

                return rowsaffected;
            }
            else
            {
                throw new ArgumentException($"Club ID {club.ClubID} does not exist on file.");
            }

        }

        

        #endregion

    }
}
