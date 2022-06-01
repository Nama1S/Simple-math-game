<?php

//variable submit by user
$loginUser = $_POST["loginUser"];
$loginPass = $_POST["loginPass"];

// Create connection
$conn = new mysqli("localhost:3308", "root", "", "astroidmaster");


// Check connection
if ($conn->connect_error) 
{
  die("Connection Failed");
}

$sql = "SELECT Username FROM players WHERE Username = '".$loginUser."'";
$result = $conn->query($sql);

if ($result->num_rows > 0) 
{
	//Tell user that username already tacken
	echo("5");
}
else 
{
	//Insesrt user details 	
  	$sql2 = "INSERT INTO players (Username, Password)
VALUES ('".$loginUser."', '".$loginPass."')";
	if($conn->query($sql2)===TRUE)
		{
			//Registered successfully
			echo ("1");
		}
		else
		{
			//Account not exist
			echo ("4");
		}
}
$conn->close();
?>	