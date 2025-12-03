var banks = Array.Empty<int[]>();
using (var reader = new StreamReader("input")){
    banks = [..
        reader.ReadToEnd().Split("\r\n").Select(b => b.ToCharArray().Select(c => Convert.ToInt32(c.ToString())).ToArray())
    ];
}

Console.WriteLine(banks.Sum(b => {
    var remainingInts = b;
    var digits = "";
    for (int i = 12; i > 0; i--) {
        var largest = remainingInts[..^(i-1)].Max();
        digits += largest.ToString();
        remainingInts = remainingInts.Skip(remainingInts.IndexOf(largest) + 1).ToArray();
    }
    return Convert.ToInt64(digits);
}));