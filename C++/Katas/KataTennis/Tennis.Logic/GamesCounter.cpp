#include <cstdint>
#include "include/Player.h"
#include "include/IGames.h"
#include "include/GamesCounter.h"

namespace Tennis
{
    namespace Logic
    {
        int8_t GamesCounter::count_games_for_player (
            const Player player,
            const IGames* games )
        {
            GameStatus game_status =
                    One == player
                        ? PlayerOneWon
                        : PlayerTwoWon;

            int8_t counter = 0;

            size_t number_of_games = games->get_length();

            for ( size_t i = 0 ; i < number_of_games ; i++ )
            {
                IGame* game = ( *games ) [ i ]; // todo should be set.game[i], mock access []

                if ( game_status == game->get_status() )
                {
                    counter++;
                }
            }

            return counter;
        }
    };
};
