var moves = Array.Empty<int>();
using (var reader = new StreamReader("input")){
    moves = [..reader.ReadToEnd().Split("\r\n").Select(l =>
        Convert.ToInt32(l.Substring(1)) * (l.Substring(0, 1) == "L" ? -1 : 1)
    )];
}

var pointer = 50;
var password = 0;

foreach (var move in moves) {
    pointer += move;
    while (pointer > 99) {
        pointer -= 100;
    }
    while (pointer < 0) {
        pointer += 100;
    }

    if (pointer == 0) {
        password++;
    }
}

Console.WriteLine(password);