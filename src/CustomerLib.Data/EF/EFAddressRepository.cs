using CustomerLib.Entities;
using System.Collections.Generic;

namespace CustomerLib.Data.EF
{
    public class EFAddressRepository
    {
        private CustomerDataContext _context;
        public EFAddressRepository()
        {
            _context = new CustomerDataContext();
        }

        public void Create(Address address)
        {
            _context.Addresses.Add(address);
            _context.SaveChanges();
        }

        public Address Read(int addressId)
        {
            return _context.Addresses.Find(addressId);
        }

        public void Update(Address updatedAddress)
        {
            Address address = Read(updatedAddress.AddressID);
            address.Line1 = updatedAddress.Line1;
            address.Line2 = updatedAddress.Line2;
            address.PostalCode = updatedAddress.PostalCode;
            address.City = updatedAddress.City;
            address.State = updatedAddress.State;
            address.AddressType = updatedAddress.AddressType;
            address.Country = updatedAddress.Country;
            _context.SaveChanges();
        }

        public void Delete(int addressId)
        {
            _context.Addresses.Remove(_context.Addresses.Find(addressId));
            _context.SaveChanges();
        }

        public List<Address> ReadAllAddresses(int customerId)
        {
            List<Address> addresses = new List<Address>();
            foreach(Address address in _context.Addresses){
                if (address.CustomerID == customerId)
                    addresses.Add(address);
            }
            if (addresses.Count == 0)
                return null;
            return addresses;
        }
    }
}
