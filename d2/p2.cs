var ranges = Array.Empty<(long low, long high)>();
using (var reader = new StreamReader("input")){
    ranges = [..
        reader.ReadToEnd().Split(",")
        .Select(r => r.Split('-'))
        .Select(r => (Convert.ToInt64(r[0]), Convert.ToInt64(r[1])))
    ];
}

long total = 0;

foreach (var range in ranges) {
    for (long idNumber = range.low; idNumber <= range.high; idNumber++) {
        var id = idNumber.ToString();
        if (Enumerable.Range(2, id.Length).Any(d => id.Length % d == 0 && new HashSet<string>(Enumerable.Range(0, d).Select(i => id.Substring(i * id.Length / d, id.Length / d))).Count() == 1)) {
            total += idNumber;
        }
    }
}

Console.WriteLine(total);