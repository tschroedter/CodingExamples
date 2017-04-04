#pragma once

namespace Tennis
{
    namespace Logic
    {
        class ISet;

        class ISetFactory
        {
        public:
            virtual ~ISetFactory() = default;

            virtual ISet* create() = 0;
            virtual void release(ISet* set) = 0;
        };
    };
}