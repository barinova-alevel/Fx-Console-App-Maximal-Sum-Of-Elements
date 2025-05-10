# Task 3 Maximal Sum Of Elements

Program should find the maximum sum of elements in line from the list of lines.

Program will take path to file as input (user can enter path in console application or send as command line interface argument if they exist).

Each line of the file contains a number set (number separator is comma, decimal separator is point).

Result should be the number of the line with a maximum sum of elements in line.

If line contains non numeric elements - line marked as broken.

As a separate list, write a number of lines with non numeric elements (“wrong elements”).


Enhanced task (is not required, for students who feel in power to do):
If program has second CLI argument with name "-min", program must search minimal sum of elements in line from the list of lines.

As result we can run program in two modes:

1) count max sum
yourcode.exe c:\yourFile.txt

2) count min sum
yourcode.exe c:\yourFile.txt -min


Useful links:

CultureInfo Class (System.Globalization) | Microsoft Docs

NumberFormatInfo Class (System.Globalization) | Microsoft Docs

File and Stream I/O - .NET | Microsoft Docs
