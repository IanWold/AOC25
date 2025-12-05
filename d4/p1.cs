var shelves = Array.Empty<char[]>();
using (var reader = new StreamReader("input")){
    shelves = [..
        reader.ReadToEnd().Split("\r\n").Select(s => s.ToCharArray())
    ];
}

var lastRow = shelves.Length - 1;
var lastCol = shelves[0].Length - 1;
var count = 0;

for (int row = 0; row <= lastRow; row++) {
    for (int col = 0; col <= lastCol; col++) {
        if (shelves[row][col] != '@') {
            continue;
        }

        var adjacent = 0;

        if (row > 0 && col > 0 && shelves[row - 1][col - 1] == '@') {
            adjacent++;
        }

        if (row > 0 && shelves[row - 1][col] == '@') {
            adjacent++;
        }

        if (row > 0 && col < lastCol && shelves[row - 1][col + 1] == '@') {
            adjacent++;
        }

        if (col > 0 && shelves[row][col - 1] == '@') {
            adjacent++;
        }

        if (col < lastCol && shelves[row][col + 1] == '@') {
            adjacent++;
        }

        if (row < lastRow && col > 0 && shelves[row + 1][col - 1] == '@') {
            adjacent++;
        }

        if (row < lastRow && shelves[row + 1][col] == '@') {
            adjacent++;
        }

        if (row < lastRow && col < lastCol && shelves[row + 1][col + 1] == '@') {
            adjacent++;
        }

        if (adjacent < 4) {
            count++;
        }
    }
}

Console.WriteLine(count);