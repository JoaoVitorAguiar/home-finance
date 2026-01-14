import { api } from "@/services/api"
import type { TotalsByCategoryResponse, TotalsByPersonResponse } from "@/types/report"

export class ReportsService {
    static async getTotalsByPerson(): Promise<TotalsByPersonResponse> {
        const { data } = await api.get<TotalsByPersonResponse>("/reports/by-person")
        return data
    }

    static async getTotalsByCategory(): Promise<TotalsByCategoryResponse> {
        const { data } = await api.get<TotalsByCategoryResponse>("/reports/by-category")
        return data
    }
}