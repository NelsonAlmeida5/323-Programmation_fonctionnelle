// ⛑️ AIDE-MÉMOIRE POUR LE TEST — C# / Programmation fonctionnelle / LINQ
// ---------------------------------------------------------------------
// Objectif : garder l'essentiel avec de petits exemples exécutables et 
// des commentaires simples pour se rappeler quoi faire le jour J.
// NB: On peut lancer ce fichier comme une petite démo console, mais ce n'est pas obligatoire.

using System;
using System.Linq;              // ← Opérateurs LINQ (Where, Select, GroupBy, Aggregate, …)
using System.Collections.Generic;

namespace RevisionPFUN
{
    // Petit modèle pour les exemples
    public record Person(string Name, int Age, int Sisters = 0, int Brothers = 0);

    public static class Program
    {
        public static void Main()
        {
            // --- Données d'entraînement (listes immuables par convention: on recrée au besoin)
            var nums = new List<int> { 1, 2, 3, 4, 5, 6 };
            var people = new List<Person>
            {
                new("Paul",    17, Sisters:2, Brothers:1),
                new("Lucie",   18, Sisters:1, Brothers:3),
                new("Helmut",  19, Sisters:2, Brothers:1),
                new("Germaine",18, Sisters:1, Brothers:0),
                new("Pierre",  17, Sisters:0, Brothers:1),
                new("Sylvie",  18, Sisters:1, Brothers:0),
                new("Ernest",  14, Sisters:2, Brothers:1),
                new("Sidonie", 18, Sisters:1, Brothers:2),
                new("Claude",  16, Sisters:0, Brothers:0),
            };

            // =============================================================
            // 1) FONCTIONS PURES & IMMUTABILITÉ (idées clés)
            // -------------------------------------------------------------
            // • Pure = même entrée → même sortie, pas d'effets secondaires.
            // • Effet secondaire typique: écrire/mettre à jour ailleurs (Console, fichier, DB…).
            // • Immuable = on NE modifie PAS l'objet d'origine; on crée un nouvel objet.

            int DoublePur(int x) => x * 2;                     // ← pure
            var x = 5;
            var y = DoublePur(x);                              // x reste 5, y vaut 10

            // Exemple d'"immutabilité": au lieu de changer la Person, on crée une copie avec "with"
            var paul18 = people[0] with { Age = 18 };          // people[0] n'est pas modifié

            // (Impur typique) : Console.WriteLine(); on l'utilise pour apprendre, mais c'est un effet secondaire.
            Console.WriteLine($"DoublePur(5) = {y}");

            // =============================================================
            // 2) LAMBDAS, ACTION, FUNC (fonctions d'ordre supérieur)
            // -------------------------------------------------------------
            // • Lambda: paramètres => corps. Peut remplacer une fonction courte.
            // • Action<T> : prend T, ne retourne rien. Func<TIn,…,TOut> : retourne une valeur.

            Action<int> Print = n => Console.WriteLine($"n = {n}");
            Func<int, int> X2 = n => n * 2;
            Func<int, int, int> Add = (a, b) => a + b;

            Print(X2(3)); // 6
            Console.WriteLine(Add(2, 3)); // 5

            // Une fonction qui PREND une autre fonction (↑ ordre supérieur)
            int ApplyTwice(int value, Func<int, int> f) => f(f(value));
            Console.WriteLine(ApplyTwice(2, X2)); // 8 (2→4→8)

            // =============================================================
            // 3) IEnumerable & LINQ : DEFERRED + PIPELINE
            // -------------------------------------------------------------
            // • IEnumerable<T> permet d'enchaîner Where / Select / … sans tout calculer tout de suite
            //   (exécution différée). On matérialise avec ToList()/ToArray() si besoin.

            // === FILTER (Where) : garder ce qui respecte une condition
            var pairs = nums.Where(n => n % 2 == 0).ToList();  // [2,4,6]

            // === MAP/SELECT : transformer chaque élément
            var doubles = nums.Select(n => n * 2).ToList();    // [2,4,6,8,10,12]

            // === COMBO : d'abord filtrer, puis transformer
            var pairsX10 = nums.Where(n => n % 2 == 0)
                               .Select(n => n * 10)
                               .ToList();                     // [20,40,60]

            Console.WriteLine($"pairs:   {string.Join(",", pairs)}");
            Console.WriteLine($"doubles: {string.Join(",", doubles)}");
            Console.WriteLine($"p*10:    {string.Join(",", pairsX10)}");

            // === Quelques opérateurs utiles (mémo) ===
            // Distinct()            : supprime doublons
            // OrderBy(x => key)     : tri asc. (ThenBy pour 2e clé)
            // GroupBy(x => key)     : groupes (clé → éléments)
            // Take(n) / Skip(n)     : pagination simple
            // Any() / All()         : existe ? / tous ?
            // First()/FirstOrDefault: 1er élément (ou défaut)

            // GroupBy: grouper par taille de fratrie (Sisters+Brothers)
            var groups = people
                .GroupBy(p => p.Sisters + p.Brothers)
                .OrderBy(g => g.Key)
                .Select(g => new { FamilySize = g.Key, Members = g.Select(p => p.Name) })
                .ToList();

            foreach (var g in groups)
                Console.WriteLine($"Famille {g.FamilySize}: {string.Join(',', g.Members)}");

            // =============================================================
            // 4) REDUCE / ACCUMULATE : des séquences → une valeur
            // -------------------------------------------------------------
            // • Opérateurs standards: Sum, Min/Max, Count, Average…
            var sum = nums.Sum();                 // 1+2+3+4+5+6 = 21
            var min = nums.Min();                 // 1
            var avg = nums.Average();             // 3.5
            Console.WriteLine($"sum={sum}, min={min}, avg={avg}");

            // • Aggregate : réducteur générique (sans seed)
            var prod = nums.Aggregate((acc, next) => acc * next); // 1*2*3*4*5*6
            Console.WriteLine($"prod={prod}");

            // • Aggregate avec SEED (valeur de départ) et éventuellement TRANSFORMATION finale
            var sommeAvecSeed = nums.Aggregate(0, (acc, n) => acc + n); // seed 0 → 21
            var resume = nums.Aggregate(
                seed: 0,
                func: (acc, n) => acc + n,
                resultSelector: total => $"Somme: {total}");
            Console.WriteLine(resume);

            // Min custom sur un type: sélectionner la personne avec le moins de frères
            var minBroName = people.Aggregate(
                seed: new Person("?", 0, Brothers: int.MaxValue),
                func: (best, p) => p.Brothers < best.Brothers ? p : best,
                resultSelector: p => p.Name);
            Console.WriteLine($"Moins de frères: {minBroName}");

            // =============================================================
            // 5) MÉTHODES D'EXTENSION (syntaxe DSL, chaînage fluide)
            // -------------------------------------------------------------
            // • Principe: méthode statique dans une classe statique, 1er paramètre préfixé par 'this'.
            // • Permet d'écrire: donnees.MaMethode() au lieu de MaMethode(donnees)

            Console.WriteLine("Bob".Greetings());     // → "Hello Bob"
            new[] { "BoB", "Max", "jOelLe", "NadiA" }
                .Where(n => n.StartsWith("j", StringComparison.OrdinalIgnoreCase))
                .ToLower(random: false)               // notre extension ci-dessous
                .ToList()
                .ForEach(Console.WriteLine);

            // =============================================================
            // 6) MINI FICHE MÉMO (ultra-condensé)
            // -------------------------------------------------------------
            // Pureté    : entrée seule → sortie, pas d'effet secondaire.
            // Immuable  : on recrée des valeurs (records, copies) plutôt que muter.
            // Where     : FILTRER (garder).  Select : MAPPER (transformer).
            // GroupBy   : regrouper (clé → éléments).  OrderBy : trier.
            // Aggregate : réduire (avec ou sans seed + resultSelector).
            // Matérialiser: ToList()/ToArray() pour exécuter maintenant.
            // Action/Func: signatures de fonctions pour passer du comportement.
        }
    }

    // ----------- Extensions perso pour la démo ----------------------------------
    public static class MyExtensions
    {
        public static string Greetings(this string name) => $"Hello {name}";

        /// <summary>
        /// Met en minuscule une séquence de chaînes, avec option aléatoire (démo).
        /// </summary>
        public static IEnumerable<string> ToLower(this IEnumerable<string> source, bool random)
        {
            var rnd = new Random();
            return source.Select(text =>
                random ? (rnd.Next(2) == 1 ? text.ToLowerInvariant() : text)
                       : text.ToLowerInvariant());
        }
    }
}
