using System;
using src.DonationRegister.Classes;
using src.DonationRegister.Enum;

namespace DonationRegister
{
    class Program
    {
        static RegisterDonation register = new RegisterDonation();

        static void Main(string[] args)
        {
            string userOption = GetUserOption();

            while (userOption.ToUpper() != "X")
            {
                switch (userOption)
                {
                    case "1":
                        ListDonation();
                        break;
                    case "2":
                        AddDonation();
                        break;
                    case "3":
                        ViewDonation();
                        break;                     
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                userOption = GetUserOption();
            }

            Console.WriteLine("Doe, Troque, Contribua!");
            Console.ReadLine();
        }

        private static void ViewDonation()
        {
            Console.Write("Digite o id da doação: ");
            int donationIndex = int.Parse(Console.ReadLine());

            var donation = register.ReturnForId(donationIndex);

            Console.WriteLine(donation);
        }

        private static void ListDonation()
        {
            Console.WriteLine("=====Listar doações=====");

            var listing = register.List();

            if (listing.Count == 0)
            {
                Console.WriteLine("Nenhuma doação cadastrada.");
                return;
            }

            foreach (var donation in listing)
            {
                Console.WriteLine("#ID {0}: - {1}", donation.returnId(), donation.returnProduct());
            }
        }


        private static void AddDonation()
        {
            Console.WriteLine("=====Cadastrar nova doação=====");

            foreach (int i in Enum.GetValues(typeof(TypeDonation)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(TypeDonation), i));
            }
            Console.Write("Digite o tipo de doação conforme as opções acima: ");
            int enterType = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do produto a ser doado: ");
            string enterName = Console.ReadLine();

            Console.Write("Digite a data de cadastro da doação (formato dd/MM/yyyy):");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime enterDate))
            {
                Console.Write($"Data inválida! Dados não salvos. Tente novamente. ");
                return;
            }

            Console.Write("Descreva brevemente o produto a ser doado: ");
            string enterDescription = Console.ReadLine();

            var today = DateTime.Now.Date;
            var registryDay = enterDate.Date; 
            var differenceOfDays = today - registryDay;
            var totalDaysInRegister = differenceOfDays.TotalDays;

            Donation newDonation = new Donation(id: register.NextId(),
                                        type: (TypeDonation)enterType,
                                        product: enterName,
                                        register: registryDay,
                                        description: enterDescription,
                                        days: totalDaysInRegister);

            register.Add(newDonation);
        }
        private static string GetUserOption()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("===Cadastro de Doações GoodHands====");
            Console.ResetColor();
            Console.WriteLine("Olá, informe a opção desejada:");

            Console.WriteLine("1- Listar doações");
            Console.WriteLine("2- Cadastrar nova doação");
            Console.WriteLine("3- Visualizar doação");
            Console.WriteLine("X- Sair do programa");
            Console.WriteLine();

            string userOption = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userOption;
        }
    }
}