**Deswik.MyTasks Test**
This program is part of a task tracking system.

The company wants to enter an employee's Id to see when 
they will be able to finish all their assigned tasks.
Each subsidary has different work hours (eg. 8 hours per day, 7.5 hours per day, etc). 
Also, each employee could work a different FTE (full time equivalent). 


**Example**
An employee with an FTE of 0.5 working for a company with an 
8 hour work day would only work 4 hours each day. To simplify the test, 
we assume employees work every day. If this employee has a 12 hour task, 
it will take 3 days to complete it.


**Your job** 
The program has already been written by a junior programmer, but apparently the
customer said its 'full of bugs' and refused to accept it.

Add some automated tests for this process. We want to make sure the logic to calculate
the finish date is correct. Fix any bugs you find along the way.

Also keep in mind that the automated tests cannot use any exteral services (eg. a database)
because we must run it on our build server. So make sure your tests just test the calculation logic
without connecting to a database. You will need to refactor the code to acheive this.


**To pass**
Fix the bugs, all your tests pass, they verify the expected functionality.


**Optional**
Moq is installed if you want to use it.