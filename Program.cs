using StringPair = (string, string);

const int GenerateSentenceNumber = 3;

Dictionary<StringPair, List<string>> ngrams = [];
var word1 = string.Empty;
var word2 = string.Empty;

// Build ngrams table indexed by pair of prefix words (w1, w2)
foreach (var line in Stdin_ReadLines()) {
    foreach (var word in SplitWords(line)) {
        AddTrio(
            ngrams,
            (word1, word2), word );

        (word1, word2) = (word2, word);
    }
}

// Avoid empty ngrams lists at end of input
AddTrio( ngrams, (word1, word2), string.Empty );
AddTrio( ngrams, (word2, string.Empty), string.Empty );

// Print interesting ngrams
//foreach (var k in ngrams.Keys) {
//    if (ngrams[k].Count >= 2)
//        Console.WriteLine( $"{k.Item1}, {k.Item2}: {string.Join( " | ", ngrams[k] )}" );
//}

var output = new List<string>();
(word1, word2) = FindRandomCapitalLetterWord( ngrams );
output.Add( word1 );
output.Add( word2 );

int sentences = 0;
for (int i = 0; i < ngrams.Count; i++) {
    var words = ngrams[(word1, word2)];
    var word =
        words.ElementAt(
            words.Count == 1 ? 0
            : Random.Shared.Next( words.Count ) );

    output.Add( word );

    if (word.Contains( '.' )) sentences++;
    if (sentences >= GenerateSentenceNumber) break;

    (word1, word2) = (word2, word);
}

Console.WriteLine(
    string.Join( ' ', output ) );

static string[] SplitWords( string line )
    => line.Split( ' ',
        StringSplitOptions.RemoveEmptyEntries
        | StringSplitOptions.TrimEntries );

static void AddTrio(
    Dictionary<StringPair, List<string>> ngrams,
    StringPair pair,
    string word )
{
    if (ngrams.TryGetValue( pair, out List<string>? value ))
        value.Add( word );
    else
        ngrams[pair] = [word];
}

static StringPair FindRandomCapitalLetterWord(
    Dictionary<StringPair, List<string>> ngrams )
{
    for (int i = 0; i < ngrams.Count; i++) {
        var pairIndex = Random.Shared.Next( ngrams.Count );
        var pair = ngrams.Keys.ElementAt( pairIndex );
        if (pair.Item1.FirstOrDefault() is char ch)
            if (char.IsUpper( ch )) return pair;
    }

    return (string.Empty, string.Empty);
}

static IEnumerable<string> Stdin_ReadLines()
{
    string? line;
    while ((line = Console.ReadLine()) != null)
        yield return line;
}
