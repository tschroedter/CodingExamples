How to build the ‘Minesight’ solution?

- Open the file ‘Minesight.sln’ with Visual Studio 2013 and build it.
- Run the NUnit test to make sure everything is working.

=> The result will be a console and WPF application!

How to start the ‘Minesight’ console application?

1. After building the solution in Visual Studio 2013 make 'Evaluation.Console' the default 'StartUp Project. 
   Click the ‘Start’ or ‘Debug’ button.
   This will start the application using the default options.

2. You can also start the application from a command window.
   - Open a command window 
   - Press the Windows key + R and type 
   - In the search window type: cmd
   - Click ‘Ok’
   - Change into the folder containing the binaries
   -- In the command window type: cd <folder>
      e.g. cd C:\Minesight\Evaluation.Console\bin\Debug\
   -- Start the application by typing: Evaluation.Console.exe
      This will start the application using the following default options.


Command Line Parameters

The Evaluation.Console.exe application accepts the following options:
-s or –source                : the name of the CSV file containing points (e.g. –s Points.csv)
-q or –queryPoint            : the query point’s coordinates              (e.g. –q="-1.0 2.0 3.0")
-m or –moveByVector          : the move/shift vector’s coordinates        (e.g. –q="-1.0 2.0 3.0")
-n or –numberOfClosestPoints : the number of closest points ids to return (e.g. –n 1)
-v or -verbose               : show additional information                (e.g. -v)

The application is using the following default options:
–s Points.csv
–q="0.0 0.0 0.0"
–m="0.0 0.0 0.0"
-p 1

Example:
Evaluation.Console.exe -s Points.csv –q=”1.0 2.0 3.0” –m=”4.0 5.0 6.0” -n 5



How to start the ‘Minesight’ WPF application?

1. After building the solution in Visual Studio 2013 make 'Evaluation.Wpf.Application' the default 'StartUp Project. 
   Click the ‘Start’ or ‘Debug’ button.
   This will start the application using the default options.

2. You can also start the application from a command window.
   - Open a command window 
   - Press the Windows key + R and type 
   - In the search window type: cmd
   - Click ‘Ok’
   - Change into the folder containing the binaries
   -- In the command window type: cd <folder>
      e.g. cd C:\Minesight\Evaluation.Wpf.Application\bin\Debug\
   -- Start the application by typing: Evaluation.Wpf.Application.exe
