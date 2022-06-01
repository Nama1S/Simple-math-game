<?php

//variable submit by user
$User = $_POST["User"];
$Level = $_POST["Level"];
$DateTime = $_POST["DateTime"];
$Score = $_POST["Score"];

// Create connection
$conn = new mysqli("localhost:3308", "root", "", "astroidmaster");


// Check connection
if ($conn->connect_error) 
{
	die("Connection Failed");
}
else
{
	$sql = "SELECT Score AND DateTime FROM scores WHERE Username = '".$User."' AND Level = '".$Level."'";
	$result = $conn->query($sql);

	if ($result->num_rows > 0)
	{
		$sql2 = "UPDATE scores SET Score = '".$Score."'  WHERE Username = '".$User."' AND Level = '".$Level."';" ;
		$conn->query($sql2);
		
		$sql3 = "UPDATE scores SET DateTime = '".$DateTime."' WHERE Username = '".$User."' AND Level = '".$Level."';" ;
		$conn->query($sql3);
	}
	else
	{
		$sql4 =  "INSERT INTO scores (Username, Level, DateTime, Score) VALUES ('".$User."', '".$Level."', '".$DateTime."', '".$Score."')";
		$conn->query($sql4);
	}
	
}
$conn->close();
?>	