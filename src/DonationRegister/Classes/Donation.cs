using System;
using src.DonationRegister.Enum;

namespace src.DonationRegister.Classes
{
    public class Donation : BaseEntity
    {
        private TypeDonation Type { get; set; }
        public TypeDonation TypeDonation { get; }
        private string Product { get; set; }
        private string Description { get; set; }
        private DateTime Register { get; set; }
        private double Days { get; set; }

        public Donation(int id, TypeDonation type, string product, string description, DateTime register, double days)
        {
            this.Id = id;
            this.TypeDonation = type;
            this.Product = product;
            this.Description = description;
            this.Register = register;
            this.Days = days;
        }

        public override string ToString()
        {
            string returned = "";
            returned += "Tipo: " + this.Type + Environment.NewLine;
            returned += "Nome: " + this.Product + Environment.NewLine;
            returned += "Descrição: " + this.Description + Environment.NewLine;
            returned += "Data de registro: " + this.Register + Environment.NewLine;
            returned += "Total de dias de registro: " + this.Days + Environment.NewLine;
            return returned;
        }

        public string returnProduct()
        {
            return this.Product;
        }

        public int returnId()
        {
            return this.Id;
        }

    }
}
