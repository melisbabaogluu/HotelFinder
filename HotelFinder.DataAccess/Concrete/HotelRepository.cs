﻿using HotelFinder.DataAccess.Interface;
using HotelFinder.Entites;
using System.Collections.Generic;
using System.Linq;

namespace HotelFinder.DataAccess.Concrete
{
    public class HotelRepository : IHotelRepository
    {
        public Hotel CreateHotel(Hotel hotel)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                hotelDbContext.Hotels.Add(hotel);
                hotelDbContext.SaveChanges();   
                return hotel;   
            }
        }

        public void DeleteHotel(int id)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                var deleteHotel = GetHotelById(id);
                hotelDbContext.Hotels.Remove(deleteHotel);
                hotelDbContext.SaveChanges();   
            }
        }

        public List<Hotel> GetAllHotels()
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                return hotelDbContext.Hotels.ToList();
            }
        }

        public Hotel GetHotelById(int id)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                return hotelDbContext.Hotels.Find(id);
            }
        }

        public Hotel GetHotelByName(string name)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                return hotelDbContext.Hotels.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());   
            }
        }

        public Hotel UpdateHotel(Hotel hotel)
        {
            using (var hotelDbContext = new HotelDbContext()) 
            {
                hotelDbContext.Hotels.Update(hotel);   
                hotelDbContext.SaveChanges();   
                return hotel;
            }
        }
    }
}
