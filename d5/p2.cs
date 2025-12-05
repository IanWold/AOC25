var ranges = Array.Empty<Range>();

using (var reader = new StreamReader("inputRanges")){
    ranges = [..
        reader.ReadToEnd().Split("\r\n").Select(r => {
            var rangeSplit = r.Split("-");
            return new Range(Convert.ToInt64(rangeSplit[0]), Convert.ToInt64(rangeSplit[1]));
        })
    ];
}

var curedRanges = new List<Range>();

foreach (var r in ranges.OrderBy(r => r.Low)) {
    if (curedRanges.Count == 0 || r.Low > curedRanges[^1].High) {
        curedRanges.Add(new Range(r.Low, r.High));
    }
    else {
        curedRanges[^1] = new Range(
            curedRanges[^1].Low,
            Math.Max(curedRanges[^1].High, r.High)
        );
    }
}

Console.WriteLine(curedRanges.Sum(c => (c.High - c.Low) + 1));

record Range(long Low, long High);