using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marché
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue au marché !");

            List<Product> products = new List<Product>();

            // Emplacement 1 - Bornand
            products.Add(new Product() { Location = "1", Provider = "Bornand", Name = "Pommes", Quantity = 20, Unit = "kg", Price = 6.90m });
            products.Add(new Product() { Location = "1", Provider = "Bornand", Name = "Poires", Quantity = 16, Unit = "kg", Price = 3.50m });
            products.Add(new Product() { Location = "1", Provider = "Bornand", Name = "Pastèques", Quantity = 14, Unit = "pièce", Price = 6.00m });
            products.Add(new Product() { Location = "1", Provider = "Bornand", Name = "Melons", Quantity = 5, Unit = "kg", Price = 7.00m });

            // Emplacement 2 - Dumont
            products.Add(new Product() { Location = "2", Provider = "Dumont", Name = "Noix", Quantity = 20, Unit = "sac", Price = 8.60m });
            products.Add(new Product() { Location = "2", Provider = "Dumont", Name = "Raisin", Quantity = 6, Unit = "kg", Price = 5.60m });
            products.Add(new Product() { Location = "2", Provider = "Dumont", Name = "Pruneaux", Quantity = 13, Unit = "kg", Price = 8.10m });
            products.Add(new Product() { Location = "2", Provider = "Dumont", Name = "Myrtilles", Quantity = 12, Unit = "kg", Price = 8.90m });
            products.Add(new Product() { Location = "2", Provider = "Dumont", Name = "Groseilles", Quantity = 12, Unit = "kg", Price = 5.20m });

            // Emplacement 3 - Vonlanthen
            products.Add(new Product() { Location = "3", Provider = "Vonlanthen", Name = "Pêches", Quantity = 8, Unit = "kg", Price = 8.70m });
            products.Add(new Product() { Location = "3", Provider = "Vonlanthen", Name = "Haricots", Quantity = 6, Unit = "kg", Price = 6.90m });
            products.Add(new Product() { Location = "3", Provider = "Vonlanthen", Name = "Courges", Quantity = 18, Unit = "pièce", Price = 4.30m });
            products.Add(new Product() { Location = "3", Provider = "Vonlanthen", Name = "Tomates", Quantity = 12, Unit = "kg", Price = 9.40m });
            products.Add(new Product() { Location = "3", Provider = "Vonlanthen", Name = "Pommes", Quantity = 20, Unit = "kg", Price = 3.90m });

            // Emplacement 4 - Barizzi
            products.Add(new Product() { Location = "4", Provider = "Barizzi", Name = "Poires", Quantity = 5, Unit = "kg", Price = 6.30m });
            products.Add(new Product() { Location = "4", Provider = "Barizzi", Name = "Pastèques", Quantity = 6, Unit = "pièce", Price = 2.50m });
            products.Add(new Product() { Location = "4", Provider = "Barizzi", Name = "Melons", Quantity = 14, Unit = "kg", Price = 4.20m });
            products.Add(new Product() { Location = "4", Provider = "Barizzi", Name = "Noix", Quantity = 20, Unit = "sac", Price = 7.50m });
            products.Add(new Product() { Location = "4", Provider = "Barizzi", Name = "Raisin", Quantity = 15, Unit = "kg", Price = 7.20m });

            // Emplacement 5 - Blanc
            products.Add(new Product() { Location = "5", Provider = "Blanc", Name = "Pruneaux", Quantity = 5, Unit = "kg", Price = 9.00m });
            products.Add(new Product() { Location = "5", Provider = "Blanc", Name = "Myrtilles", Quantity = 18, Unit = "kg", Price = 5.60m });
            products.Add(new Product() { Location = "5", Provider = "Blanc", Name = "Groseilles", Quantity = 10, Unit = "kg", Price = 2.10m });
            products.Add(new Product() { Location = "5", Provider = "Blanc", Name = "Pêches", Quantity = 20, Unit = "kg", Price = 6.40m });
            products.Add(new Product() { Location = "5", Provider = "Blanc", Name = "Haricots", Quantity = 9, Unit = "kg", Price = 2.90m });

            // Emplacement 6 - Repond
            products.Add(new Product() { Location = "6", Provider = "Repond", Name = "Courges", Quantity = 12, Unit = "pièce", Price = 7.40m });
            products.Add(new Product() { Location = "6", Provider = "Repond", Name = "Tomates", Quantity = 12, Unit = "kg", Price = 4.20m });
            products.Add(new Product() { Location = "6", Provider = "Repond", Name = "Pommes", Quantity = 15, Unit = "kg", Price = 6.50m });
            products.Add(new Product() { Location = "6", Provider = "Repond", Name = "Poires", Quantity = 18, Unit = "kg", Price = 2.40m });
            products.Add(new Product() { Location = "6", Provider = "Repond", Name = "Pastèques", Quantity = 7, Unit = "pièce", Price = 5.70m });

            // Emplacement 7 - Mancini
            products.Add(new Product() { Location = "7", Provider = "Mancini", Name = "Pêche", Quantity = 10, Unit = "kg", Price = 2.90m });
            products.Add(new Product() { Location = "7", Provider = "Mancini", Name = "Haricots", Quantity = 11, Unit = "kg", Price = 6.70m });
            products.Add(new Product() { Location = "7", Provider = "Mancini", Name = "Courges", Quantity = 10, Unit = "pièce", Price = 6.40m });
            products.Add(new Product() { Location = "7", Provider = "Mancini", Name = "Tomates", Quantity = 13, Unit = "kg", Price = 1.50m });
            products.Add(new Product() { Location = "7", Provider = "Mancini", Name = "Pommes", Quantity = 14, Unit = "kg", Price = 7.00m });

            // Emplacement 8 - Favre
            products.Add(new Product() { Location = "8", Provider = "Favre", Name = "Poires", Quantity = 5, Unit = "kg", Price = 8.40m });
            products.Add(new Product() { Location = "8", Provider = "Favre", Name = "Pastèques", Quantity = 5, Unit = "pièce", Price = 1.70m });
            products.Add(new Product() { Location = "8", Provider = "Favre", Name = "Haricots", Quantity = 5, Unit = "kg", Price = 3.00m });
            products.Add(new Product() { Location = "8", Provider = "Favre", Name = "Courges", Quantity = 17, Unit = "pièce", Price = 2.00m });
            products.Add(new Product() { Location = "8", Provider = "Favre", Name = "Tomates", Quantity = 9, Unit = "kg", Price = 5.20m });

            // Emplacement 9 - Bovay
            products.Add(new Product() { Location = "9", Provider = "Bovay", Name = "Pommes", Quantity = 13, Unit = "kg", Price = 7.70m });
            products.Add(new Product() { Location = "9", Provider = "Bovay", Name = "Poires", Quantity = 5, Unit = "kg", Price = 3.80m });
            products.Add(new Product() { Location = "9", Provider = "Bovay", Name = "Pastèques", Quantity = 20, Unit = "pièce", Price = 2.10m });
            products.Add(new Product() { Location = "9", Provider = "Bovay", Name = "Melons", Quantity = 20, Unit = "kg", Price = 6.40m });
            products.Add(new Product() { Location = "9", Provider = "Bovay", Name = "Noix", Quantity = 13, Unit = "sac", Price = 8.80m });

            // Emplacement 10 - Cherix
            products.Add(new Product() { Location = "10", Provider = "Cherix", Name = "Raisin", Quantity = 8, Unit = "kg", Price = 7.10m });
            products.Add(new Product() { Location = "10", Provider = "Cherix", Name = "Pruneaux", Quantity = 19, Unit = "kg", Price = 7.90m });
            products.Add(new Product() { Location = "10", Provider = "Cherix", Name = "Myrtilles", Quantity = 9, Unit = "kg", Price = 4.20m });
            products.Add(new Product() { Location = "10", Provider = "Cherix", Name = "Groseilles", Quantity = 10, Unit = "kg", Price = 4.40m });
            products.Add(new Product() { Location = "10", Provider = "Cherix", Name = "Pêches", Quantity = 9, Unit = "kg", Price = 4.40m });

            // Emplacement 11 - Beaud
            products.Add(new Product() { Location = "11", Provider = "Beaud", Name = "Haricots", Quantity = 19, Unit = "kg", Price = 8.40m });
            products.Add(new Product() { Location = "11", Provider = "Beaud", Name = "Courges", Quantity = 16, Unit = "pièce", Price = 8.70m });
            products.Add(new Product() { Location = "11", Provider = "Beaud", Name = "Tomates", Quantity = 18, Unit = "kg", Price = 5.30m });
            products.Add(new Product() { Location = "11", Provider = "Beaud", Name = "Pommes", Quantity = 8, Unit = "kg", Price = 7.30m });
            products.Add(new Product() { Location = "11", Provider = "Beaud", Name = "Poires", Quantity = 13, Unit = "kg", Price = 9.20m });

            // Emplacement 12 - Corbaz
            products.Add(new Product() { Location = "12", Provider = "Corbaz", Name = "Pastèques", Quantity = 15, Unit = "pièce", Price = 7.40m });
            products.Add(new Product() { Location = "12", Provider = "Corbaz", Name = "Melons", Quantity = 12, Unit = "kg", Price = 1.60m });
            products.Add(new Product() { Location = "12", Provider = "Corbaz", Name = "Noix", Quantity = 11, Unit = "sac", Price = 7.50m });
            products.Add(new Product() { Location = "12", Provider = "Corbaz", Name = "Raisin", Quantity = 16, Unit = "kg", Price = 4.50m });
            products.Add(new Product() { Location = "12", Provider = "Corbaz", Name = "Pruneaux", Quantity = 20, Unit = "kg", Price = 3.30m });

            // Emplacement 13 - Amaudruz
            products.Add(new Product() { Location = "13", Provider = "Amaudruz", Name = "Myrtilles", Quantity = 18, Unit = "kg", Price = 5.70m });
            products.Add(new Product() { Location = "13", Provider = "Amaudruz", Name = "Groseilles", Quantity = 19, Unit = "kg", Price = 8.00m });
            products.Add(new Product() { Location = "13", Provider = "Amaudruz", Name = "Pêches", Quantity = 12, Unit = "kg", Price = 5.50m });
            products.Add(new Product() { Location = "13", Provider = "Amaudruz", Name = "Haricots", Quantity = 13, Unit = "kg", Price = 5.20m });
            products.Add(new Product() { Location = "13", Provider = "Amaudruz", Name = "Courges", Quantity = 7, Unit = "pièce", Price = 9.60m });

            // Emplacement 14 - Bühlmann
            products.Add(new Product() { Location = "14", Provider = "Bühlmann", Name = "Tomates", Quantity = 12, Unit = "kg", Price = 7.70m });
            products.Add(new Product() { Location = "14", Provider = "Bühlmann", Name = "Pommes", Quantity = 17, Unit = "kg", Price = 1.90m });
            products.Add(new Product() { Location = "14", Provider = "Bühlmann", Name = "Poires", Quantity = 7, Unit = "kg", Price = 3.00m });
            products.Add(new Product() { Location = "14", Provider = "Bühlmann", Name = "Pastèques", Quantity = 11, Unit = "pièce", Price = 6.90m });
            products.Add(new Product() { Location = "14", Provider = "Bühlmann", Name = "Melons", Quantity = 7, Unit = "kg", Price = 4.70m });

            // Emplacement 15 - Crizzi
            products.Add(new Product() { Location = "15", Provider = "Crizzi", Name = "Noix", Quantity = 10, Unit = "sac", Price = 1.60m });
            products.Add(new Product() { Location = "15", Provider = "Crizzi", Name = "Raisin", Quantity = 17, Unit = "kg", Price = 7.80m });
            products.Add(new Product() { Location = "15", Provider = "Crizzi", Name = "Pruneaux", Quantity = 18, Unit = "kg", Price = 9.00m });
            products.Add(new Product() { Location = "15", Provider = "Crizzi", Name = "Myrtilles", Quantity = 12, Unit = "kg", Price = 3.00m });
            products.Add(new Product() { Location = "15", Provider = "Crizzi", Name = "Groseilles", Quantity = 12, Unit = "kg", Price = 3.50m });

            /*
            // ---- PASTÈQUES ----
            var watermelons = products.Where(p => p.Name.ToLower() == "pastèques").ToList();

            // Trouver celui qui en a le plus
            var maxWatermelon = watermelons.OrderByDescending(p => p.Quantity).First();
            */


            // ---- Pêches ----
            int peachVendors = products
                .Where(p => p.Name.ToLower().StartsWith("pêche"))
                .Select(p => p.Provider)
                .Distinct()
                .Count();

            // ---- Pastèques ----
            var maxWatermelon = products
                .Where(p => p.Name.ToLower() == "pastèques")
                .OrderByDescending(p => p.Quantity)
                .First();

            // ---- Résultats ----
            Console.WriteLine($"Il y a {peachVendors} vendeurs de pêches");
            Console.WriteLine($"C'est {maxWatermelon.Provider} qui a le plus de pastèques (stand {maxWatermelon.Location}, {maxWatermelon.Quantity} {maxWatermelon.Unit})");

            // La quantité de groseilles disponibles sur le marché
            int totalGroseilles = products
            .Where(p => !string.IsNullOrEmpty(p.Name) &&
                p.Name.Equals("Groseilles", StringComparison.OrdinalIgnoreCase))
            .Sum(p => p.Quantity);

            Console.WriteLine($"Il y a {totalGroseilles} groseilles disponibles sur le marché");


            // Le chiffre d’affaire possible total pour chaque marchand (tout produit confondu)
            var turnoverByVendor = products
            .GroupBy(p => p.Provider)   // étape 1 : on regroupe par marchand
            .Select(g => new
            {
               Vendor = g.Key,         // g.Key = le nom du marchand (Provider)
               Turnover = g.Sum(p => p.Quantity * p.Price) // étape 2 : somme du CA
            });

            foreach (var v in turnoverByVendor)
            {
                Console.WriteLine($"{v.Vendor} peut gagner {v.Turnover} CHF");
            }

            // Le plus grand, le plus petit et la moyenne de ces chiffres d’affaire
            var turnovers = products
             .GroupBy(p => p.Provider)
             .Select(g => g.Sum(p => p.Quantity * p.Price));

            decimal maxTurnover = turnovers.Max();
            decimal minTurnover = turnovers.Min();
            decimal avgTurnover = turnovers.Average();

            Console.WriteLine($"Le plus grand chiffre d’affaire est {maxTurnover} CHF");
            Console.WriteLine($"Le plus petit chiffre d’affaire est {minTurnover} CHF");
            Console.WriteLine($"La moyenne des chiffres d’affaires est {avgTurnover} CHF");

            // Le marchand ayant le plus de noix à vendre
            var maxWalnutsVendor = products
            .Where(p => p.Name.Equals("Noix", StringComparison.OrdinalIgnoreCase)) // on filtre
            .GroupBy(p => p.Provider) // on regroupe par vendeur
            .Select(g => new
            {
                Vendor = g.Key,
                TotalNoix = g.Sum(p => p.Quantity) // on additionne les quantités
            })
            .OrderByDescending(g => g.TotalNoix) // du plus grand au plus petit
            .First(); // on garde le premier (le max)

            Console.WriteLine($"C'est {maxWalnutsVendor.Vendor} qui a le plus de noix ({maxWalnutsVendor.TotalNoix} unités)");


            // Le marchand ayant le plus d’affinités avec ses produits
            var vendorWithMostAffinities = products
            .GroupBy(p => p.Provider)
            .Select(g => new
            {
                Vendor = g.Key,
                Affinities = g.Count(p => g.Key.ToLower().Contains(p.Name.ToLower()))
            })
            .OrderByDescending(g => g.Affinities)
            .First();

            Console.WriteLine($"C'est {vendorWithMostAffinities.Vendor} qui a le plus d'affinités avec ses produits ({vendorWithMostAffinities.Affinities})");

        }
    }

    public class Product
    {
        public string Location { get; set; }
        public string Provider { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
    }
}
