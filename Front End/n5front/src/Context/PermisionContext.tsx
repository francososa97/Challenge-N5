import React, { createContext, useState, useEffect } from 'react';

export const PermisionContext = createContext({});

const PermisionProvider = (props) => {

    const typeOfPermission = ["Modify","Request","Get"]
    return (
        <PermisionContext.Provider
            value={{typeOfPermission}}
        >
            {props.children}
        </PermisionContext.Provider>
    )
}
export default PermisionProvider;