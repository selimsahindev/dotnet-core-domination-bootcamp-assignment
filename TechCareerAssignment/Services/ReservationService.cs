using AutoMapper;
using TechCareerAssignment.Data;
using TechCareerAssignment.Dtos;
using TechCareerAssignment.Models;

namespace TechCareerAssignment.Services
{
    public class ReservationService : IReservationService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public ReservationService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all reservations
        /// </summary>
        public IEnumerable<ReservationDto> GetReservations()
        {
            return _dbContext.Reservations.Select(r => _mapper.Map<ReservationDto>(r));
        }

        /// <summary>
        /// Get reservation by id
        /// </summary>
        /// <param name="id"></param>
        public ReservationDto GetReservationById(int id)
        {
            return _mapper.Map<ReservationDto>(_dbContext.Reservations.FirstOrDefault(r => r.Id == id));
        }

        /// <summary>
        /// Create a new reservation
        /// </summary>
        /// <param name="reservationDto"></param>
        public ReservationDto CreateReservation(ReservationCreateDto reservationDto)
        {
            var reservation = _mapper.Map<Reservation>(reservationDto);

            _dbContext.Reservations.Add(reservation);
            _dbContext.SaveChanges();

            return _mapper.Map<ReservationDto>(reservation);
        }

        /// <summary>
        /// Update an existing reservation
        /// </summary>
        /// <param name="id"></param>
        /// <param name="reservationDto"></param>
        public ReservationDto UpdateReservation(int id, ReservationUpdateDto reservationDto)
        {
            var existingReservation = _dbContext.Reservations.FirstOrDefault(r => r.Id == id);

            if (existingReservation == null)
            {
                return null;
            }

            _mapper.Map(reservationDto, existingReservation);

            _dbContext.SaveChanges();

            return _mapper.Map<ReservationDto>(existingReservation);
        }

        /// <summary>
        /// Delete an existing reservation
        /// </summary>
        /// <param name="id"></param>
        public ReservationDto DeleteReservation(int id)
        {
            var existingReservation = _dbContext.Reservations.FirstOrDefault(r => r.Id == id);

            if (existingReservation == null)
            {
                return null;
            }

            _dbContext.Reservations.Remove(existingReservation);
            _dbContext.SaveChanges();

            return _mapper.Map<ReservationDto>(existingReservation);
        }
    }

}
