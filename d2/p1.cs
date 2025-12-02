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
        if (id.Length % 2 == 0 && id.Substring(0, id.Length/2) == id.Substring(id.Length/2)) {
            total += idNumber;
        }
    }
}

Console.WriteLine(total);