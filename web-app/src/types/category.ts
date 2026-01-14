export type Category = {
    id: number
    description: string
    purpose: CategoryPurpose
}

export type CategoryPurpose = "Expense" | "Income" | "Both"
