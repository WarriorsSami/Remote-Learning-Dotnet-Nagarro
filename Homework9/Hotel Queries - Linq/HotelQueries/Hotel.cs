using System;
using System.Collections.Generic;
using System.Linq;
using iQuest.HotelQueries.Domain;

namespace iQuest.HotelQueries
{
    public class Hotel
    {
        public List<Room> Rooms { get; set; } = new List<Room>();

        public List<Customer> Customers { get; set; } = new List<Customer>();

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

        /// <summary>
        /// 1) Return a collection with all rooms that can accomodate exactly 2 persons.
        /// </summary>
        public IEnumerable<Room> GetAllRoomsForTwoPersons()
        {
            return Rooms.Where(room => room.MaxPersonCount == 2);
        }

        /// <summary>
        /// 2) Return all customers whose full name contains the specified searched text.
        /// The search must be case insensitive.
        /// </summary>
        public IEnumerable<Customer> FindCustomerByName(string text)
        {
            return Customers.Where(
                customer => customer.FullName.ToLower().Contains(text.ToLower())
            );
        }

        /// <summary>
        /// 3) Return all reservations made by companies.
        /// </summary>
        public IEnumerable<Reservation> GetCompanyReservations()
        {
            return Reservations.Where(reservation => reservation.Customer is CompanyCustomer);
        }

        /// <summary>
        /// 4) Return all women customers that last checked in a specific period of time.
        /// </summary>
        public IEnumerable<Customer> FindWomen(DateTime startTime, DateTime endTime)
        {
            return Customers.Where(
                customer =>
                    customer is PersonCustomer { Gender: PersonGender.Female } customerPerson
                    && customerPerson.LastAccommodation >= startTime
                    && customerPerson.LastAccommodation <= endTime
            );
        }

        /// <summary>
        /// 5) Calculate how many persons can the hotel accomodate.
        /// </summary>
        public int CalculateHotelCapacity()
        {
            return Rooms.Sum(room => room.MaxPersonCount);
        }

        /// <summary>
        /// 6) Return a single page containing a number of exactly pageSize Rooms, ordered by surface.
        /// The pageNumber starts from 0.
        ///
        /// This is useful when paginating a large number of items in order to display them in a webpage.
        /// </summary>
        public IEnumerable<Room> GetPageOfRoomsOrderedBySurface(int pageNumber, int pageSize)
        {
            return Rooms.OrderBy(room => room.Surface).Skip(pageNumber * pageSize).Take(pageSize);
        }

        /// <summary>
        /// 7) Return the rooms sorted by <see cref="Room.MaxPersonCount"/> in a descending order.
        /// If two rooms have the same number of max persons, sort them further by <see cref="Room.Number"/> in ascending order.
        /// </summary>
        public IEnumerable<Room> GetRoomsOrderedByCapacity()
        {
            return Rooms.OrderByDescending(room => room.MaxPersonCount).ThenBy(room => room.Number);
        }

        /// <summary>
        /// 8) Return all reservations for the specified customer.
        /// The reservations must be ordered from the most recent one to the oldest one.
        /// </summary>
        public IEnumerable<Reservation> GetReservationsOrderedByDateFor(int customerId)
        {
            return Reservations
                .Where(reservation => reservation.Customer.Id == customerId)
                .OrderByDescending(reservation => reservation.StartDate);
        }

        /// <summary>
        /// 9) Return a dictionary with the customers grouped by the last accommodation's year.
        /// The years must be enumerated in descending order.
        /// Customers must be ordered by full name.
        /// </summary>
        public List<KeyValuePair<int, Customer[]>> GetCustomersGroupedByYear()
        {
            return Customers
                .GroupBy(customer => customer.LastAccommodation.Year)
                .OrderByDescending(group => group.Key)
                .Select(
                    group =>
                        new KeyValuePair<int, Customer[]>(
                            group.Key,
                            group.OrderBy(customer => customer.FullName).ToArray()
                        )
                )
                .ToList();
        }

        /// <summary>
        /// 10) Calculate the average number of reservation per month.
        /// Consider the start date as the date of the reservation.
        /// </summary>
        public double CalculateAverageReservationsPerMonth()
        {
            return Reservations
                .GroupBy(reservation => reservation.StartDate.Month)
                .Average(group => group.Count());
        }

        /// <summary>
        /// 11) Find all reservations that have a conflict with other ones and return a dictionary containing the reservation as key
        /// and the list of conflicting reservations as value.
        /// The reservations that does not have conflicts should not be present in the dictionary.
        /// </summary>
        public IDictionary<Reservation, List<Reservation>> GetConflictingReservations()
        {
            return Reservations
                .GroupBy(reservation => reservation)
                .Select(
                    group =>
                    {
                        var conflictingReservations = Reservations.Where(
                            otherReservation => group.Key.ConflictsWith(otherReservation)
                        );

                        return new KeyValuePair<Reservation, List<Reservation>>(
                            group.Key,
                            conflictingReservations.ToList()
                        );
                    }
                )
                .Where(pair => pair.Value.Count != 0)
                .ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        /// <summary>
        /// 12) We have a reservation for a room, but there is a conflict: there is another reservation for the same room.
        /// Your task is to propose another similar room for the reservation.
        /// 
        /// A similar room is a room that has the same number of maximum occupants or greater, has air conditioner if
        /// the original reserved room had, is disabled friendly if the original reserved room was and
        /// has balcony if the original reserved room had one.
        /// </summary>
        public Room FindNewFreeRoomFor(Reservation reservation)
        {
            var reservationsInConflict = Reservations.Where(
                otherReservation =>
                    otherReservation.ConflictsWith(reservation.StartDate, reservation.EndDate)
            );

            return Rooms
                .Where(
                    room =>
                        room.Number != reservation.Room.Number
                        && room.MaxPersonCount >= reservation.Room.MaxPersonCount
                        && room.HasAirConditioner == reservation.Room.HasAirConditioner
                        && room.IsDisabledFriendly == reservation.Room.IsDisabledFriendly
                        && room.HasBalcony == reservation.Room.HasBalcony
                )
                .FirstOrDefault(
                    room =>
                        Reservations.All(
                            otherReservation =>
                                otherReservation.Room.Number != room.Number
                                || (otherReservation.Room.Number == room.Number
                                && !reservationsInConflict.Contains(otherReservation))
                        )
                );
        }
    }
}
