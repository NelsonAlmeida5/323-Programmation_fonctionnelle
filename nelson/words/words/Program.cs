// Exercice words https://github.com/NelsonAlmeida5/323-Programmation_fonctionnelle/tree/main/exos/words

string[] words = { "bonjour", "hello", "monde", "vert", "rouge", "bleu", "jaune" };


// A. Filtrage basique
// Ne contiennent pas la lettre x
Func<string, bool> noX = w => !w.Contains('x');

// Ont 4 caractères ou plus
Func<string, bool> length4OrMore = w => w.Length >= 4;

// Ont autant de caractères que la moyenne
double avgLength = words.Average(w => w.Length);
Func<string, bool> equalToAverage = w => w.Length == avgLength;

// B.Données parasites 1
string[] words2 = {
    "whatThe!!!",
    "bonjour", "hello", "monde", "vert", "rouge", "bleu", "jaune",
    "My kingdom for a horse !",
    "Ooops I did it again"
};

// Filtrage des parasites
var cleaned = words2.Skip(1).SkipLast(2);

// Affichage
Console.WriteLine("Liste nettoyée :");
foreach (var w in cleaned)
{
    Console.WriteLine(w);
}



