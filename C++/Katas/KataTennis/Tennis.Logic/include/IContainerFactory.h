#pragma once

#pragma once
namespace Tennis
{
    namespace Logic
    {
        template <class T>
        class IContainerFactory
        {
        public:
            virtual ~IContainerFactory () = default;

            virtual T* create () = 0;
            virtual void release ( T* item ) = 0;
        };
    };
};
