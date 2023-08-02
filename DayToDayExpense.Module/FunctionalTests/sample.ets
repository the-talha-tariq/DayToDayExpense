;#DropDB DayToDayExpenseEasyTest

#Application DayToDayExpenseWin
#Application DayToDayExpenseWeb

*FillForm
 User Name = Admin
*Action Log In

#IfDef DayToDayExpenseWin

*Action About...
 
*Action OK

#EndIf

#IfDef DayToDayExpenseWeb
*Action Navigation(My Details)
#EndIf
