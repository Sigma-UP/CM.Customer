using CustomerLib.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerLib.Data.EF
{
    public class EFCustomerRepository
    {
        private CustomerDataContext _context;
        public EFCustomerRepository()
        {
            _context = new CustomerDataContext();
        }

        public void Create(Customer customer)
        {
            foreach (Address address in customer.Addresses)
                _context.Addresses.Add(address);
            foreach (Note note in customer.Notes)
                _context.Notes.Add(note);
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public Customer Read(int customerId)
        {
            var readedCustomer = _context.Customers.Find(customerId);
            if (readedCustomer != null)
            {
                var addressRepo = new EFAddressRepository();
                readedCustomer.Addresses = addressRepo.ReadAllAddresses(customerId);
                var noteRepo = new EFNoteRepository();
                readedCustomer.Notes = noteRepo.ReadAllNotes(customerId);
            }
            return readedCustomer;
        }

        public void Update(Customer updatedAddress)
        {
            Customer address = Read(updatedAddress.CustomerID);
            address.FirstName = updatedAddress.FirstName;
            address.LastName = updatedAddress.LastName;
            address.PhoneNumber = updatedAddress.PhoneNumber;
            address.Addresses = updatedAddress.Addresses;
            address.Notes = updatedAddress.Notes;
            address.TotalPurchasesAmount = updatedAddress.TotalPurchasesAmount;
            address.Email = updatedAddress.Email;
        }

        public void Delete(int customerId)
        {
            var notes = _context.Notes.ToList();
            foreach (var note in notes)
            {
                if(note.CustomerID == customerId)
                _context.Notes.Remove(note);
            }
            var addresses = _context.Addresses.ToList();
            foreach (var address in addresses)
            {
                if(address.CustomerID == customerId)
                _context.Addresses.Remove(address);
            }

            _context.Customers.Remove(_context.Customers.Find(customerId));
            _context.SaveChanges();
        }

        public void DeleteAll()
        {
            var customers = _context.Customers.ToList();

            foreach(var customer in customers)
            {
                _context.Customers.Remove(customer);
            }

            _context.SaveChanges();
        }

        public List<Customer> ReadAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            foreach(Customer customer in _context.Customers)
            {
                customers.Add(customer);
                customer.Notes = new EFNoteRepository().ReadAllNotes(customer.CustomerID);
                customer.Addresses = new EFAddressRepository().ReadAllAddresses(customer.CustomerID);
            }
            return _context.Customers.ToList();
        }
    }
}
