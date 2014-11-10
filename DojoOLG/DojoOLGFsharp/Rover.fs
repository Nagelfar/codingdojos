namespace DojoOLGFsharp

type Position(x:int, y:int) = struct
    member this.X = x
    member  this.Y = y

    member this.Add(otherX:int,otherY:int) = new Position(x+otherX,y+otherY)

    member this.North() = this.Add(0,1)
    member this.South() = this.Add(0,-1)
    member this.East() = this.Add(1,0)
    member this.West() = this.Add(-1,0)    

    static member (+) (lhs:Position, rhs: Position) = new Position(lhs.X + rhs.X,lhs.Y + rhs.Y)
    static member( ~-)(position:Position) = new Position(-position.X,-position.Y)
    end

type Heading(direction:char) = struct
        
    member this.Move(position:Position) = 
        match direction with
            |'N' -> position.North()
            |'S' -> position.South()
            |'E' -> position.East()
            |'W' -> position.West()
            | _ -> position
    
    member this.RotateLeft() =   
        match direction with
            | 'N' -> new Heading( 'W')
            | 'E' -> new Heading( 'N')
            | 'S' -> new Heading( 'E')
            | 'W' -> new Heading( 'S')
            | _-> this
    member this.Invert() = this.RotateLeft().RotateLeft()

    end

type Rover(position:Position, heading:Heading) = struct
    member this.Execute(action:char) = 
        match action with
        | 'f' -> new Rover(heading.Move(position),heading)
        | 'b' -> new Rover(heading.Invert().Move(position),heading)
        | 'l' -> new Rover(position, heading.RotateLeft())
        | 'r' -> new Rover(position, heading.Invert().RotateLeft())
        | _->this

    end