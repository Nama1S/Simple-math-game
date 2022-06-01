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

$sql = "SELECT Password FROM players WHERE Username = '".$loginUser."'";
$result = $conn->query($sql);

if ($result->num_rows > 0) 
{
	while($row =$result->fetch_assoc())
	{
		if($row["Password"]==$loginPass)
		{
			//Login successfully
			echo "1";
		}
		else
		{
			//Wrong password
			echo "2";
		}
	}
}
else 
{
	//Account does not exist
	echo "3";
}
$conn->close();
?>	