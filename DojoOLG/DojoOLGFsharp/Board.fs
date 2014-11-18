namespace DojoOLGFsharp


type BoardSize(width:int, height:int)  = 
    member this.Wrap(position:Position) = new Position(this.WrapX(position.X ), this.WrapY(position.Y))   
    member this.WrapX(x:int) = x % width    
    member this.WrapY(y:int) = y % height

