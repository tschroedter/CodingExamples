namespace KataBankOCR

module TextDigitModule = 
    type TextDigit =
       { Line1 : string;
         Line2 : string;
         Line3 : string }

    let textDigitZero  =    
        {
            Line1 = " _ ";
            Line2 = "| |";
            Line3 = "|_|"
        }

    let textDigitOne  =    
        {
            Line1 = "   ";
            Line2 = "  |";
            Line3 = "  |"
        }

    let textDigitTwo  =    
        {
            Line1 = " _ ";
            Line2 = " _|";
            Line3 = "|_ "
        }

    let textDigitThree  =    
        {
            Line1 = " _ ";
            Line2 = " _|";
            Line3 = " _|"
        }

    let textDigitFour  =    
        {
            Line1 = "   ";
            Line2 = "|_|";
            Line3 = "  |"
        }

    let textDigitFive  =    
        {
            Line1 = " _ ";
            Line2 = "|_ ";
            Line3 = " _|"
        }

    let textDigitSix  =    
        {
            Line1 = " _ ";
            Line2 = "|_ ";
            Line3 = "|_|"
        }

    let textDigitSeven  =    
        {
            Line1 = " _ ";
            Line2 = "  |";
            Line3 = "  |"
        }

    let textDigitEight  =    
        {
            Line1 = " _ ";
            Line2 = "|_|";
            Line3 = "|_|"
        }

    let textDigitNine  =    
        {
            Line1 = " _ ";
            Line2 = "|_|";
            Line3 = "  |"
        }