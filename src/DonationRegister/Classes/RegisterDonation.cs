using System.Collections.Generic;
using src.DonationRegister.Interfaces;

namespace src.DonationRegister.Classes
{
    public class RegisterDonation : IRegister<Donation>
    {
        private List<Donation> listDonation = new List<Donation>();

        public void Add(Donation obj)
        {
            listDonation.Add(obj);
        }

        public List<Donation> List()
        {
            return listDonation;
        }

        public int NextId()
        {
            return listDonation.Count;
        }

        public Donation ReturnForId(int id)
        {
            return listDonation[id];
        }
    }
}
