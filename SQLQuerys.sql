use EmployeeDB

select * from Employee

--Insert Sp
Create procedure AddEmployee         
(        
    @Name VARCHAR(20),         
    @City VARCHAR(20),        
    @Department VARCHAR(20),        
    @Gender VARCHAR(6)        
)        
as         
Begin         
    Insert into tblEmployee (Name,City,Department, Gender)         
    Values (@Name,@City,@Department, @Gender)         
End  

--Update Store Pro.
alter procedure UpdateEmployee          
(          
   @ID INTEGER ,        
   @Name VARCHAR(20),         
   @City VARCHAR(20),        
   @Department VARCHAR(20),        
   @Gender VARCHAR(6)        
)          
as          
begin   
	IF EXISTS (SELECT 1 FROM Employee WHERE Id = @Id)
	BEGIN
   Update Employee           
   set Name=@Name,          
   City=@City,          
   Department=@Department,        
   Gender=@Gender          
   
   SELECT Name,city,Department,gender from Employee
   end
End 


--Delete Record data
CREATE PROCEDURE DeleteEmployee
(
   @Id INT
)
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM Employee
        WHERE Id = @Id
    )
    BEGIN
        DELETE FROM Employee
        WHERE Id = @Id;

        PRINT 'Employee deleted successfully.';
    END
    ELSE
    BEGIN
        PRINT 'Employee does not exist.';
    END
END
   
