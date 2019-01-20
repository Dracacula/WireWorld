using System;
using System.Collections.Generic;
using System.Text;

namespace V1
{
    partial class WireWorld
    {
        // aOld Matrix mit der n-ten Generation
        // aNew Matrix mit der n+1-ten Generation
        void CalcNextGeneration(CellTypes[,] oldGrid, CellTypes[,] newGrid)
        {
            CellTypes cellType;
            for (int i = 0; i < MAX_CELLS; i++)
            {

                for (int j = 0; j < MAX_CELLS; j++)
                {
                    cellType = oldGrid[i, j];
                    if (cellType.Equals(CellTypes.ElectronHead))
                        newGrid[i, j] = CellTypes.ElectronTail;
                    else if (cellType.Equals(CellTypes.ElectronTail))
                        newGrid[i, j] = CellTypes.Conductor;
                    else if (cellType.Equals(CellTypes.Conductor))
                        if (GetNeighbourCount(i, j) == 1 || GetNeighbourCount(i, j) == 2)
                            newGrid[i, j] = CellTypes.ElectronHead;
                        else
                            newGrid[i, j] = CellTypes.Conductor;
                }

            }

        }

        void ClearCells(CellTypes[,] aCells)
        {
            // alle Zellen von aCells auf false
            for (int i = 0; i < MAX_CELLS; i++)
            {
                for (int j = 0; j < MAX_CELLS; j++)
                {
                    aCells[i, j] = 0;
                }
            }



        }

        // cells of _CC
        void TurnCellOnOff(int aX, int aY)
        {
            // Cell an der Stelle aX,aY toggeln ( Umschalten )
            if (aX < MAX_CELLS && aY < MAX_CELLS)
            {
                if (_CC[aX, aY].Equals(currentMode))
                    _CC[aX, aY] = CellTypes.Empty;
                else if (aX < MAX_CELLS && aY < MAX_CELLS)
                    _CC[aX, aY] = currentMode;
            }




        }

        // cells of _CC
        int GetNeighbourCount(int i, int j)
        {
            // 
            int summe = 0;


            if (ValOf(i - 1, j - 1))
                summe++;

            if (ValOf(i - 1, j))
                summe++;

            if (ValOf(i, j - 1))
                summe++;

            if (ValOf(i + 1, j + 1))
                summe++;

            if (ValOf(i + 1, j))
                summe++;

            if (ValOf(i, j + 1))
                summe++;

            if (ValOf(i - 1, j + 1))
                summe++;

            if (ValOf(i + 1, j - 1))
                summe++;


            // wieviele lebende Nachbarn hat Cell(i,j)
            return summe;
        }

        // Ist Cell(i,j) von _CC on oder off ?
        // mit richtiger Behandlung von i,j<0 und i,j>=MAX_CELLS
        bool ValOf(int i, int j)
        {
            if (i < 0)
                i = MAX_CELLS - 1;

            if (j < 0)
                j = MAX_CELLS - 1;

            if (i >= MAX_CELLS)
                i = 0;

            if (j >= MAX_CELLS)
                j = 0;


            //Wenn der Rand erreicht wird false

            if (_CC[i, j].Equals(CellTypes.ElectronHead))
                return true;
            else
                return false;
        }

    }
}
