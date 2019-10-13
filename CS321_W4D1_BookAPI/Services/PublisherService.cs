using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS321_W4D1_BookAPI.Models;
using CS321_W4D1_BookAPI.Data;

namespace CS321_W4D1_BookAPI.Services
{
    public class PublisherService : IPublisherService
    {
        private readonly BookContext _bookContext;
        public PublisherService(BookContext bookContext)
        {
            _bookContext = bookContext;
        }
        public IEnumerable<Publisher> GetAll()
        {
            return _bookContext.Publishers.ToList();
        }
        public Publisher Get(int publisherId)
        {
            return _bookContext.Publishers.FirstOrDefault(p => p.Id == publisherId);
        }
        public Publisher Add(Publisher newPublisher)
        {
            _bookContext.Publishers.Add(newPublisher);
            _bookContext.SaveChanges();
            return newPublisher;
        }
        public Publisher Update(Publisher updatedPublisher)
            {
            var currentPublisher = _bookContext.Publishers.FirstOrDefault(p => p.Id == updatedPublisher.Id);
            if (currentPublisher == null) return null;
            _bookContext.Entry(currentPublisher).CurrentValues.SetValues(updatedPublisher); // instead of typing out each field
            _bookContext.Publishers.Update(currentPublisher);
            _bookContext.SaveChanges();
            return currentPublisher;
                
        }
        public void Remove(Publisher publisher)
        {
            _bookContext.Publishers.Remove(publisher);
            _bookContext.SaveChanges();
        }
           

    }
}
