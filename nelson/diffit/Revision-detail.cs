// ============================================================================
// PROGRAMME DE RÉVISION — VERSION MÉGA DÉTAILLÉE (format Program.cs)
// Thème : Programmation fonctionnelle en C# + LINQ + Mini-projet DIFFIT
// ----------------------------------------------------------------------------
// 🧭 Objectif de ce fichier :
//   - Servir de "pense-bête" très commenté pour le test.
//   - Tout tient dans un seul fichier .cs pour un usage rapide pendant l'épreuve.
//   - Le code est écrit comme un vrai Program.cs (exécutable),
//     MAIS tu peux aussi simplement le lire comme aide-mémoire.
//
// 🧠 Notions clés révisées ici (liées au cours et au DIFFIT) :
//   1) Fonctions pures & immutabilité (pourquoi c'est utile)
//   2) Lambdas, Action, Func (fonctions d'ordre supérieur)
//   3) IEnumerable<T> & LINQ (Where = filtrer, Select = transformer, etc.)
//   4) Aggregate (Reduce) avec seed + resultSelector
//   5) Zip pour comparer deux séquences élément par élément
//   6) Méthodes d'extension (syntaxe DSL fluide)
//   7) DIFFIT : Lire fichiers → Nettoyer → Comparer → Afficher diffs colorés → Chiffrer
//   8) Astuces & pièges du test (performance, erreurs communes)
//
// ❗ Rappels rapides
//   - Pur = même entrée → même sortie, sans effet secondaire.
//   - Immuable = on recrée une valeur/objet au lieu de modifier en place.
//   - Exécution différée LINQ = la requête s'exécute quand on l'énumère (foreach, ToList...).
//   - Matérialiser = forcer exécution (ToArray/ToList) si on veut figer le résultat maintenant.
//   - Zip(s1, s2) s'arrête à la plus petite longueur → penser à gérer le "reste" soi-même.
//
// ⚠️ Pendant le test :
//   - Lis le message d'erreur EXACT → montre que tu gères les cas invalides.
//   - Écris des petites fonctions pures (faciles à tester) + compose-les (Aggregate).
//   - Toujours commenter en 1 ligne ce que fait une requête LINQ (intention).
// ============================================================================

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace RevisionPFUN
{
    public static class Program
    {
        public static void Main()
        {
            // ----------------------------------------------------------------
            // PARTIE A — MINI-RAPPELS PRATIQUES (fonctionnel + LINQ)
            // ----------------------------------------------------------------

            // 1) Fonction pure : pas d'effet externe, prévisible
            int DoublePur(int x) => x * 2; // Toujours même résultat pour x donné

            // 2) Fonctions d'ordre supérieur via Func / Action
            Func<int, int> fX2 = n => n * 2; // transforme un int → int
            Action<string> log = msg => Console.WriteLine(msg); // effet secondaire OK (log)

            // 3) IEnumerable + LINQ (Where/Select)
            var nums = new[] { 1, 2, 3, 4, 5, 6 };
            var pairs = nums.Where(n => n % 2 == 0);   // filtre seulement les pairs
            var pairsX10 = pairs.Select(n => n * 10);  // transforme chaque n → n*10
            // exécution réelle ici (ToArray matérialise)
            var arr = pairsX10.ToArray();
            log($"Pairs*10: {string.Join(",", arr)}");

            // 4) Reduce/Aggregate : replier une séquence vers une seule valeur
            var sum = nums.Aggregate(0, (acc, n) => acc + n); // seed 0 → somme
            log($"Somme = {sum}");

            // ----------------------------------------------------------------
            // PARTIE B — DIFFIT COMPLET, TRÈS COMMENTÉ
            // ----------------------------------------------------------------
            // DIFFIT = mini outil console qui :
            //   (1) Lit 2 fichiers textes (même nb de lignes)
            //   (2) Applique éventuellement un "nettoyage" (espaces/tabs/casse)
            //   (3) Compare chaque ligne (A vs B) caractère par caractère
            //   (4) Affiche le nb de lignes identiques/différentes + un diff coloré
            //   (5) Chiffre le fichier A (César) dans cipheredA.txt (optionnel)
            //
            // 👉 Tout est découpé en petites fonctions pures quand c'est possible.

            Console.WriteLine("\n+--------------------------------+");
            Console.WriteLine("|DIFFIT : A very limited DIFFTOOL|");
            Console.WriteLine("+--------------------------------+\n");

            // --- Entrées utilisateur : chemins de fichiers
            Console.Write("Fichier A: ");
            string? pathA = Console.ReadLine();
            Console.Write("Fichier B: ");
            string? pathB = Console.ReadLine();

            // --- Validation des chemins (défensif)
            // Astuce LINQ : Aggregate(true, (acc, p) => acc && ...)
            var paths = new string?[] { pathA, pathB };
            bool filesAreValid = paths.Aggregate(true, (ok, p) => ok && p != null && File.Exists(p));
            if (!filesAreValid)
            {
                Console.WriteLine("Erreur: les fichiers doivent être existants et accessibles !");
                return; // On arrête proprement
            }

            // --- Chargement : ReadAllLines (chaque fichier → tableau de lignes)
            string[] linesA = File.ReadAllLines(pathA!);
            string[] linesB = File.ReadAllLines(pathB!);

            // --- Vérif. même nombre de lignes (contrainte énoncé)
            if (linesA.Length != linesB.Length)
            {
                Console.WriteLine("Erreur: les fichiers n'ont pas le même nombre de ligne");
                return;
            }
            Console.WriteLine(">Fichiers chargés avec succès\n");

            // ----------------------------------------------------------------
            // 1) Définir les fonctions de NETTOYAGE (pures) et construire le pipeline
            // ----------------------------------------------------------------
            // Principe : une fonction de nettoyage prend une string et renvoie la string transformée
            //   - remove spaces, remove tabs, force lowercase, etc.
            //   - elles sont PURES → parfait pour être composées via Aggregate

            Func<string, string> cleanSpaces = s => s.Replace(" ", "");       // supprime espaces
            Func<string, string> cleanTabs = s => s.Replace("\t", "");      // supprime tabulations
            Func<string, string> enforceCase = s => s.ToLowerInvariant();       // force minuscule stable

            // --- Demande des options à l'utilisateur
            bool AskYesNo(string label)
            {
                Console.Write(label);
                return Console.ReadLine()?.Trim().ToLowerInvariant() == "o"; // 'o' pour oui
            }

            bool ignoreSpaces = AskYesNo("-Ignorer les espaces [o/n]: ");
            bool ignoreTabs = AskYesNo("-Ignorer les tabulations [o/n]: ");
            bool ignoreCase = AskYesNo("-Ignorer la casse [o/n]: ");

            // --- On construit une LISTE de fonctions à appliquer
            var cleaners = new List<Func<string, string>>();
            if (ignoreSpaces) cleaners.Add(cleanSpaces);
            if (ignoreTabs) cleaners.Add(cleanTabs);
            if (ignoreCase) cleaners.Add(enforceCase);

            // --- Composition (pipeline) : s → fN(...f2(f1(s)))
            // Trick LINQ : Aggregate applique chaque f à l'accumulateur (la string en cours)
            Func<string, string> composedClean = s => cleaners.Aggregate(s, (acc, f) => f(acc));

            // --- Application du nettoyage si nécessaire (ToArray pour matérialiser)
            if (cleaners.Count > 0)
            {
                linesA = linesA.Select(composedClean).ToArray();
                linesB = linesB.Select(composedClean).ToArray();
                Console.WriteLine(">Nettoyage appliqué\n");
            }

            // ----------------------------------------------------------------
            // 2) Construire les objets de comparaison (ligne par ligne)
            // ----------------------------------------------------------------
            // On associe linesA[i] ↔ linesB[i] + on garde l'indice (numéro de ligne)
            var comparisons = linesA
                .Select((line, index) => new LinesComparison
                {
                    Number = index,
                    ContentA = line,
                    ContentB = linesB[index]
                })
                .ToList();

            // ----------------------------------------------------------------
            // 3) Filtrer les lignes différentes + afficher le bilan
            // ----------------------------------------------------------------
            var diffLines = comparisons.Where(c => c.ContentA != c.ContentB).ToList();
            int matchingLinesCount = linesA.Length - diffLines.Count;

            Console.WriteLine($"Lignes identiques: {matchingLinesCount}");
            Console.WriteLine($"Lignes différentes: {diffLines.Count}\n");

            // ----------------------------------------------------------------
            // 4) Comptage des différences caractère par caractère
            // ----------------------------------------------------------------
            // - Zip compare A et B position par position. Il s'arrête à la plus petite longueur.
            // - Il faut AJOUTER la différence de longueur (LengthVariation) au total.

            Func<LinesComparison, int> countVariations = c =>
                c.ContentA.Zip(c.ContentB, (a, b) => a == b ? 0 : 1).Sum() + c.LengthVariation;

            // --- Afficher pour chaque ligne différente le nombre de variations
            diffLines.ForEach(c =>
                Console.WriteLine($"Ligne {c.NumberHuman} : {countVariations(c)} différences"));

            // ----------------------------------------------------------------
            // 5) Affichage DIFF COLORÉ (VERT = identique, ROUGE = différent [A/B])
            // ----------------------------------------------------------------
            foreach (var c in diffLines)
            {
                PrintColoredDiff(c); // détail ci-dessous
                Console.WriteLine();
            }

            // ----------------------------------------------------------------
            // 6) Chiffrement César (optionnel) — écriture dans cipheredA.txt
            // ----------------------------------------------------------------
            Console.Write("\nSPECIAL FEATURE: Clé de chiffrement [1-25] (Enter pour ignorer): ");
            var raw = Console.ReadLine();
            if (byte.TryParse(raw, out var key) && key >= 1 && key <= 25)
            {
                // On chiffre uniquement les lettres (A..Z / a..z) avec wrap modulo 26.
                var cipheredA = linesA.Select(line => Caesar(line, key));
                File.WriteAllLines("cipheredA.txt", cipheredA);
                Console.WriteLine(">Fichier 'cipheredA.txt' écrit. (Pour déchiffrer: utiliser 26 - clé)");
            }

            // ----------------------------------------------------------------
            // PARTIE C — ASTUCES, PIÈGES & RÉCAP (en commentaires)
            // ----------------------------------------------------------------
            // ✅ Astuces
            //   - ToLowerInvariant() > ToLower() (invariant culture → résultats stables)
            //   - Préfère des fonctions pures pour le nettoyage → facile à enchaîner
            //   - Pense à materialiser (ToArray/ToList) si tu réutilises plusieurs fois
            //   - Pour DIFF coloré, garde une couleur par défaut et restaure-la ensuite
            //   - Pour Zip, additionne bien LengthVariation sinon tu sous-comptes
            //
            // ⚠️ Pièges classiques
            //   - Oublier la validation des chemins (fichiers inexistants)
            //   - Comparer deux fichiers avec des longueurs différentes sans gérer l'erreur
            //   - Oublier d'appliquer les nettoyages sur A ET B
            //   - Oublier d'afficher les numéros en "humain" (1-based)
            //   - Chiffrer tous les caractères au lieu des lettres uniquement (évite de casser la ponctuation)
            //
            // 🧩 Vocabulaire express
            //   - Where = filtrer (garder)
            //   - Select = mapper (transformer chaque élément)
            //   - GroupBy = regrouper par clé
            //   - OrderBy / ThenBy = trier
            //   - Aggregate = réduire (avec seed + resultSelector optionnel)
            //   - Zip = fusionner 2 séquences par positions (s'arrête au plus court)
        }

        // =====================================================================
        // -------------------------- HELPERS -----------------------------------
        // =====================================================================

        // Affiche un diff coloré pour une comparaison A/B :
        // - vert = même caractère
        // - rouge = différent → affiché comme [A/B]
        private static void PrintColoredDiff(LinesComparison c)
        {
            var def = Console.ForegroundColor; // couleur de base à restaurer à la fin
            Console.WriteLine($"\n>Ligne {c.NumberHuman}:");

            foreach (var pair in c.ContentA.Zip(c.ContentB, (a, b) => (a, b)))
            {
                if (pair.a == pair.b)
                {
                    Console.ForegroundColor = ConsoleColor.Green;   // identique → vert
                    Console.Write(pair.a);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;     // différent → rouge
                    Console.Write($"[{pair.a}/{pair.b}]");
                }
            }

            Console.ForegroundColor = def; // toujours restaurer
            Console.WriteLine();
        }

        // Chiffrement César : décale uniquement les lettres (A..Z / a..z)
        private static string Caesar(string s, int key)
            => new string(s.Select(c => ShiftLetter(c, key)).ToArray());

        private static char ShiftLetter(char ch, int key)
        {
            if (char.IsLetter(ch))
            {
                char a = char.IsUpper(ch) ? 'A' : 'a';
                return (char)(a + ((ch - a + key) % 26)); // wrap 26 lettres
            }
            return ch; // chiffres/ponctuation inchangés
        }
    }

    // ------------------------------------------------------------------------
    // Modèle de donnée pour une comparaison de lignes
    //   Number         : index 0-based
    //   NumberHuman    : numéro 1-based (affichage)
    //   LengthVariation: |len(A) - len(B)| → utile pour Zip
    // ------------------------------------------------------------------------
    public class LinesComparison
    {
        public int Number { get; set; }
        public string ContentA { get; set; } = string.Empty;
        public string ContentB { get; set; } = string.Empty;

        public int NumberHuman => Number + 1;
        public int LengthVariation => Math.Abs(ContentA.Length - ContentB.Length);
    }

    // ------------------------------------------------------------------------
    // ANNEXE (optionnelle) — Méthodes d'extension simples (exemple de cours)
    //   Idée : écrire des helpers "chaînables" pour rendre le code lisible.
    // ------------------------------------------------------------------------
    public static class MyStringExtensions
    {
        // Utilisation : "Hello".SurroundedBy('*') → *Hello*
        public static string SurroundedBy(this string s, char c)
            => string.Concat(c, s, c);

        // Utilisation : "abc\t de f".RemoveTabs().RemoveSpaces()
        public static string RemoveSpaces(this string s) => s.Replace(" ", "");
        public static string RemoveTabs(this string s) => s.Replace("\t", "");
        public static string AsInvariantLower(this string s) => s.ToLowerInvariant();
    }
}
