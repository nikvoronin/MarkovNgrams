const int NumberOfSentencesToGenerate = 1;
const int PrefixWordsNumber = 2;

Dictionary<List<string>, List<string>> ngrams = new(new StringListComparer());

var prefixWords = New_EmptyStringsList( PrefixWordsNumber );

// Builds ngrams table indexed by pair of prefix words
foreach (var line in Stdin_ReadLines()) {
    foreach (var nextWord in SplitWords( line )) {
        AddNgram( ngrams, prefixWords, nextWord );
        prefixWords = prefixWords[1..]; // Creates a new list!
        prefixWords.Add( nextWord );
    }
}

// Avoid empty ngrams lists at end of input
for (int i = 0; i < PrefixWordsNumber; i++) {
    AddNgram( ngrams, prefixWords, string.Empty );
    prefixWords = prefixWords[1..];
    prefixWords.Add( string.Empty );
}

// Print interesting ngrams
//Stdout_PrintNgrams( ngrams, 2 );

var output = new List<string>();
var keyGrams = FindRandomCapitalLetterPrefixWord( ngrams );
output.AddRange( keyGrams );

int sentences = 0;
for (int i = 0; i < ngrams.Count; i++) {
    var nextWords = ngrams[keyGrams];
    var nextWord =
        nextWords.ElementAt(
            nextWords.Count == 1 ? 0
            : Random.Shared.Next( nextWords.Count ) );

    output.Add( nextWord );

    if (nextWord.Contains( '.' )) sentences++;
    if (sentences >= NumberOfSentencesToGenerate) break;

    keyGrams = keyGrams[1..];
    keyGrams.Add(nextWord );
}

Console.WriteLine(
    string.Join( ' ', output ) );

static void Stdout_PrintNgrams(
    Dictionary<List<string>, List<string>> ngrams,
    int interestNumber )
{
    foreach (var prefixWords in ngrams.Keys) {
        if (ngrams[prefixWords].Count >= interestNumber) {
            Console.WriteLine(
                $"{string.Join( " ", prefixWords )}: {string.Join( " | ", ngrams[prefixWords] )}" );
        }
    }
}

static string[] SplitWords( string line )
    => line.Split( ' ',
        StringSplitOptions.RemoveEmptyEntries
        | StringSplitOptions.TrimEntries );

static void AddNgram(
    Dictionary<List<string>, List<string>> ngrams,
    List<string> prefixWords,
    string nextWord )
{
    if (ngrams.TryGetValue( prefixWords, out List<string>? nextWords ))
        nextWords.Add( nextWord );
    else
        ngrams[prefixWords] = [nextWord];
}

static List<string> FindRandomCapitalLetterPrefixWord(
    Dictionary<List<string>, List<string>> ngrams )
{
    for (int i = 0; i < ngrams.Count; i++) {
        var gramIndex = Random.Shared.Next( ngrams.Count );
        var prefixWords = ngrams.Keys.ElementAt( gramIndex );
        if (prefixWords[0].FirstOrDefault() is char ch)
            if (char.IsUpper( ch )) return prefixWords;
    }

    return New_EmptyStringsList( PrefixWordsNumber );
}

static List<string> New_EmptyStringsList( int capacity )
    => Enumerable
    .Repeat( string.Empty, capacity )
    .ToList();

static IEnumerable<string> Stdin_ReadLines()
{
    string? line;
    while ((line = Console.ReadLine()) != null)
        yield return line;
}

// See https://stackoverflow.com/questions/54491136/create-a-dictionary-with-key-as-listof-string/54492137#54492137
sealed class StringListComparer : EqualityComparer<List<string>>
{
    public override bool Equals( List<string> x, List<string> y )
        => System.Collections.StructuralComparisons
        .StructuralEqualityComparer
        .Equals(
            x?.ToArray(),
            y?.ToArray() );

    public override int GetHashCode( List<string> x )
        => System.Collections.StructuralComparisons
        .StructuralEqualityComparer
        .GetHashCode( x?.ToArray() );
}