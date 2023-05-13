SELECT DISTINCT C1.Classroom
FROM Classes AS C1
WHERE NOT EXISTS
	((SELECT C2.CourceId
	 FROM Classes AS C2
	 WHERE C1.Classroom = C2.Classroom)
	 EXCEPT
	(SELECT CS1.Id
	 FROM Cources AS CS1
	 WHERE CS1.LevelId IN
		(SELECT L1.Id
		 FROM Levels AS L1
		 WHERE L1.Status = @P_LSTATUS))) 
	 AND NOT EXISTS 
	((SELECT CS1.Id
	 FROM Cources AS CS1
	 WHERE CS1.LevelId IN
		(SELECT L1.Id
		 FROM Levels AS L1
		 WHERE L1.Status = @P_LSTATUS))
	 EXCEPT
	(SELECT C2.CourceId
	 FROM Classes AS C2
	 WHERE C1.Classroom = C2.Classroom))