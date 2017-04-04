#pragma once
#include "ISet.h"

namespace Tennis
{
    namespace Logic
    {
        class ISets
        {
        public:
            virtual ~ISets() = default;

            virtual ISet* new_set() = 0;
            virtual ISet* get_current_set() const = 0;
            virtual ISet* operator[] (const size_t index) const = 0;
            virtual size_t get_length() const = 0;
        };
    };
};