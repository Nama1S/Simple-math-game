<?php
$User = $_POST["User"];
$Level = $_POST["Level"];

// Create connection
$conn = new mysqli("localhost:3308", "root", "", "astroidmaster");


// Check connection
if ($conn->connect_error) 
{
	die("Connection Failed");
}
else
{
	$sql = "SELECT DateTime, Score FROM scores WHERE Username = '".$User."' AND Level = '".$Level."' ";
	$result = $conn->query($sql);

	if ($result->num_rows > 0)
	{
		while($row = $result->fetch_assoc()){
			echo "".$row["Score"]."      ".$row["DateTime"]."";
		}
	}
	else
	{
		echo "0";
	}
}
$conn->close();
?>