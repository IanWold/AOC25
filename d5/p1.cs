var ranges = Array.Empty<(long low, long high)>();
var ids = Array.Empty<long>();

using (var reader = new StreamReader("inputRanges")){
    ranges = [..
        reader.ReadToEnd().Split("\r\n").Select(r => {
            var rangeSplit = r.Split("-");
            return (Convert.ToInt64(rangeSplit[0]), Convert.ToInt64(rangeSplit[1]));
        })
    ];
}

using (var reader = new StreamReader("inputIds")){
    ids = [..
        reader.ReadToEnd().Split("\r\n").Select(i => Convert.ToInt64(i))
    ];
}

var count = ids.Where(i => ranges.Any(r => i >= r.low && i <= r.high)).Count();

Console.WriteLine(count);