package com.transflower;

import junit.framework.Test;
import junit.framework.TestCase;
import junit.framework.TestSuite;

//automation Testing
//Test script
public class AppTest extends TestCase
{

    ///AAA Pattern: test stroy telling
    /// Arrange Act  Assert
    /// 
    

   //Arrange :set up everything you need for the test (objects, data, mocks).
   
    public AppTest( String testName )
    {
        super( testName );
    }

   
     //Act : perform the action you want to test (call a method).
    public static Test suite()
    {
        return new TestSuite( AppTest.class );
    }

    //Assert: verify the result (check if the output/behavior is correct).
    public void testApp()
    {
        assertTrue( true);
    }

    public void testCompareResult1()
    {
        int expectedResult=110;

        //sample

        //get data from Testdata.json, testdata.xml
        //database 
        // from rest API
        int sample1=55;
        int sample2=55;


        //Source

        MathEngine math=new MathEngine();
        int actualRestult=math.Sum(sample1, sample2);
        
        assertEquals(actualRestult,expectedResult);
    }

     public void testCompareResult2()
    {
        int expectedResult=8;

        //sample

        //get data from Testdata.json, testdata.xml
        //database 
        // from rest API
        int sample1=4;
        int sample2=4;


        //Source

        MathEngine math=new MathEngine();
        int actualRestult=math.Sum(sample1, sample2);
        
        assertEquals(actualRestult,expectedResult);
    }
}
