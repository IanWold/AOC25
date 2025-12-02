var moves = Array.Empty<int>();
using (var reader = new StreamReader("input")){
    moves = [..
        reader.ReadToEnd().Split("\r\n")
        .SelectMany(l => Enumerable.Repeat(l.Substring(0, 1) == "L" ? -1 : 1, Convert.ToInt32(l.Substring(1))))
    ];
}

var pointer = 50;
var password = 0;

foreach (var move in moves) {
    pointer += move;
    
    if (pointer == -1) pointer = 99;
    if (pointer == 100) pointer = 0;
    if (pointer == 0) password++;
}

Console.WriteLine(password);