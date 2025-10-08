// =============================================================
// 🧭 RÉVISION COURTE — DIFFIT (7 ÉTAPES ESSENTIELLES)
// Objectif : aller droit à l'essentiel pour le test, sans se noyer.
// -------------------------------------------------------------
// Chaque étape correspond à un TODO du test officiel.
// Lis les commentaires : ils t’expliquent quoi faire et pourquoi.
// =============================================================

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace RevisionShort
{
    class Program
    {
        static void Main()
        {
            // -------------------------------------------------
            // 1️⃣ LIRE LES FICHIERS
            // -------------------------------------------------
            Console.Write("Fichier A: "); string? pathA = Console.ReadLine();
            Console.Write("Fichier B: "); string? pathB = Console.ReadLine();

            // Lecture de tout le contenu texte en tableau de lignes
            string[] a = File.ReadAllLines(pathA!);
            string[] b = File.ReadAllLines(pathB!);

            if (a.Length != b.Length)
            {
                Console.WriteLine("Erreur: fichiers pas le même nombre de lignes.");
                return;
            }

            // -------------------------------------------------
            // 2️⃣ NETTOYER LE TEXTE
            // -------------------------------------------------
            // Fonctions pures simples : prennent une string → rendent une string
            Func<string, string> cleanSpaces = s => s.Replace(" ", "");
            Func<string, string> cleanTabs = s => s.Replace("\t", "");
            Func<string, string> toLower = s => s.ToLowerInvariant();

            // Exemples d’application si besoin :
            // a = a.Select(cleanSpaces).ToArray();
            // b = b.Select(cleanSpaces).ToArray();

            // -------------------------------------------------
            // 3️⃣ COMPARER LIGNE PAR LIGNE
            // -------------------------------------------------
            // On associe chaque ligne de A avec celle de B + son index
            var comparisons = a.Select((line, i) => new { Num = i + 1, A = line, B = b[i] }).ToList();

            // -------------------------------------------------
            // 4️⃣ TROUVER LES LIGNES DIFFÉRENTES
            // -------------------------------------------------
            var diffs = comparisons.Where(c => c.A != c.B).ToList();

            Console.WriteLine($"Lignes identiques: {a.Length - diffs.Count}");
            Console.WriteLine($"Lignes différentes: {diffs.Count}\n");

            // -------------------------------------------------
            // 5️⃣ COMPTER LES DIFFÉRENCES DE CARACTÈRES
            // -------------------------------------------------
            foreach (var c in diffs)
            {
                int count = c.A.Zip(c.B, (x, y) => x == y ? 0 : 1).Sum()
                           + Math.Abs(c.A.Length - c.B.Length);
                Console.WriteLine($"Ligne {c.Num} → {count} différences");
            }

            // -------------------------------------------------
            // 6️⃣ AFFICHER LES DIFFÉRENCES COLORÉES
            // -------------------------------------------------
            foreach (var c in diffs)
            {
                Console.WriteLine($"\n>Ligne {c.Num}:");
                foreach (var pair in c.A.Zip(c.B, (x, y) => (x, y)))
                {
                    Console.ForegroundColor = (pair.x == pair.y) ? ConsoleColor.Green : ConsoleColor.Red;
                    Console.Write((pair.x == pair.y) ? pair.x : $"[{pair.x}/{pair.y}]");
                }
                Console.ResetColor();
                Console.WriteLine();
            }

            // -------------------------------------------------
            // 7️⃣ CHIFFREMENT CÉSAR (bonus)
            // -------------------------------------------------
            Console.Write("\nClé de chiffrement [1-25]: ");
            if (byte.TryParse(Console.ReadLine(), out var key) && key >= 1 && key <= 25)
            {
                var ciphered = a.Select(line => new string(line.Select(ch => Shift(ch, key)).ToArray()));
                File.WriteAllLines("cipheredA.txt", ciphered);
                Console.WriteLine(">Fichier chiffré: cipheredA.txt");
            }
        }

        // --- Décalage César sur les lettres uniquement ---
        static char Shift(char c, int key)
        {
            if (char.IsLetter(c))
            {
                char baseChar = char.IsUpper(c) ? 'A' : 'a';
                return (char)(baseChar + ((c - baseChar + key) % 26));
            }
            return c; // On laisse le reste inchangé
        }
    }
}

// =============================================================
// 🧾 RÉSUMÉ RAPIDE — À RELIRE AVANT LE TEST
// -------------------------------------------------------------
// 1️⃣ ReadAllLines → lire fichiers.
// 2️⃣ Func<string,string> → nettoyages purs.
// 3️⃣ Select((val,i)) → associer lignes + index.
// 4️⃣ Where(...) → filtrer différences.
// 5️⃣ Zip + Sum → compter différences char/char.
// 6️⃣ ConsoleColor → vert = même, rouge = diff.
// 7️⃣ Caesar → décaler lettres, WriteAllLines.
// =============================================================