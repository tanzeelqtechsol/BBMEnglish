Set objFS = CreateObject("Scripting.FileSystemObject")
Set objPrint = objFS.CreateTextFile("LPT1:", True)
objPrint.Write(Chr(27) + Chr(112) + Chr(0) + Chr(25) + Chr(250))
objPrint.Close
